using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private float volume = 1f;

    void Start()
    {
        LoadSettings();
        ApplyAudioSettings();
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void OnMusicToggle()
    {
        volume = toggleMusic.isOn ? 1f : 0f;
        SaveSettings();
        ApplyAudioSettings();
    }

    public void OnVolumeSliderChanged()
    {
        volume = sliderVolumeMusic.value;
        SaveSettings();
        ApplyAudioSettings();
    }

    private void ApplyAudioSettings()
    {

        if (audioSource != null)
        {
            audioSource.volume = volume;
        }

        sliderVolumeMusic.value = volume;
        toggleMusic.isOn = volume > 0f;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(VolumePrefKey, volume);
        PlayerPrefs.SetInt(FullscreenPrefKey, System.Convert.ToInt32(Screen.fullScreen));
    }

    public void LoadSettings()
    {
        volume = PlayerPrefs.GetFloat(VolumePrefKey, 1f);

        if (PlayerPrefs.HasKey(FullscreenPrefKey))
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt(FullscreenPrefKey));
        else
            Screen.fullScreen = true;

        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void BackToMainMenu()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}

