using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle muteButton;
    public Toggle fullscreenButton;

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 1f);
        muteButton.isOn = PlayerPrefs.GetInt("mute", 0) == 1;
        fullscreenButton.isOn = PlayerPrefs.GetInt("fullscreen", 1) == 1;

        volumeSlider.onValueChanged.AddListener(delegate { ApplySettings(); });
        muteButton.onValueChanged.AddListener(delegate { ApplySettings(); });
        fullscreenButton.onValueChanged.AddListener(delegate { ApplySettings(); });

        ApplySettings();
    }

    public void ApplySettings()
    {
        AudioListener.volume = muteButton.isOn ? 0 : volumeSlider.value;
        Screen.fullScreen = fullscreenButton.isOn;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        PlayerPrefs.SetInt("mute", muteButton.isOn ? 1 : 0);
        PlayerPrefs.SetInt("fullscreen", fullscreenButton.isOn ? 1 : 0);

        PlayerPrefs.Save();
        ApplySettings();
    }

    public void Back()
    {
        gameObject.SetActive(false);
    }
}
