using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject settingsPanel;
    public GameObject mainMenuPanel;
    public Toggle fullscreenToggle;
    public Toggle toggleMusic;
    public Slider sliderVolumeMusic;

    [Header("Audio")]
    public AudioSource audioSource;

    private const string VolumePrefKey = "volume";
    private const string FullscreenPrefKey = "FullscreenPreference";

    private float tempVolume = 1f;
    private float lastVolumeBeforeMute = 1f;
    private bool tempFullscreen = true;
    private bool suppressEvents = false;

    void Start()
    {
        LoadSettings();
        ApplyUI();
    }

    public void OnMusicToggle()
    {
        if (suppressEvents) return;

        suppressEvents = true;

        if (toggleMusic.isOn) // Toggle ON => mute
        {
            lastVolumeBeforeMute = tempVolume > 0f ? tempVolume : lastVolumeBeforeMute;
            tempVolume = 0f;
            sliderVolumeMusic.value = sliderVolumeMusic.minValue;
        }
        else // Toggle OFF => restore volume
        {
            tempVolume = lastVolumeBeforeMute > 0f ? lastVolumeBeforeMute : sliderVolumeMusic.maxValue / 2f;
            sliderVolumeMusic.value = tempVolume;
        }

        ApplyAudioSettings();
        suppressEvents = false;
    }

    public void OnVolumeSliderChanged()
    {
        if (suppressEvents) return;

        suppressEvents = true;

        tempVolume = sliderVolumeMusic.value;

        if (tempVolume > 0f)
        {
            lastVolumeBeforeMute = tempVolume;
            toggleMusic.isOn = false;
        }
        else
        {
            toggleMusic.isOn = true;
        }

        ApplyAudioSettings();
        suppressEvents = false;
    }

    public void OnFullscreenToggleChanged()
    {
        tempFullscreen = fullscreenToggle.isOn;
    }

    public void OnSaveButtonClick()
    {
        SaveSettings();
        ApplyAudioSettings();
        Screen.fullScreen = tempFullscreen;
    }

    private void ApplyAudioSettings()
    {
        if (audioSource != null)
        {
            audioSource.volume = tempVolume;
        }
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(VolumePrefKey, tempVolume);
        PlayerPrefs.SetInt(FullscreenPrefKey, System.Convert.ToInt32(tempFullscreen));
    }

    public void LoadSettings()
    {
        tempVolume = PlayerPrefs.GetFloat(VolumePrefKey, 1f);
        lastVolumeBeforeMute = tempVolume > 0f ? tempVolume : 1f;

        tempFullscreen = PlayerPrefs.HasKey(FullscreenPrefKey)
            ? System.Convert.ToBoolean(PlayerPrefs.GetInt(FullscreenPrefKey))
            : true;
    }

    private void ApplyUI()
    {
        suppressEvents = true;

        sliderVolumeMusic.value = tempVolume;
        toggleMusic.isOn = tempVolume == 0f;
        fullscreenToggle.isOn = tempFullscreen;

        ApplyAudioSettings();

        suppressEvents = false;
    }

    public void BackToMainMenu()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
