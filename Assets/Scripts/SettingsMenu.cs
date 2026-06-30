using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullScreenToggle;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;


    private Resolution[] availableResolutions;

    void Start()
    {
        InitializeResolutions();

        resolutionDropdown.onValueChanged.AddListener(ApplyResolution);
        fullScreenToggle.onValueChanged.AddListener(SetFullScreen);
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);
    }

    private void InitializeResolutions()
    {
        //Tomar todas las resoliciopnes del monitor donde se está jugando
        availableResolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for(int i = 0; i < availableResolutions.Length; i++)
        {
            string resolutionOption = $"{availableResolutions[i].width} x {availableResolutions[i].height}";
            options.Add(resolutionOption);

            if(availableResolutions[i].width == Screen.currentResolution.width && availableResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }
    }

    public void ApplyResolution(int resolutionIndex)
    {
        if(resolutionIndex < 0 || resolutionIndex >= availableResolutions.Length) return;

        Resolution selectedResolution = availableResolutions[resolutionIndex];

        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed);
    }

    private void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    private void SetAudioMixerVolume(string mixerParameter, float volume)
    {
        if(!audioMixer)
        {
            Debug.LogError("Mixer is not assifned");
            return;
        }

        audioMixer.SetFloat(mixerParameter, volume > 0.0001f ? Mathf.Log10(volume) * 20 : -80f);
    }

    private void SetMasterVolume(float volume)
    {
        SetAudioMixerVolume("Master", volume);
    }


    private void SetMusicVolume(float volume)
    {
        SetAudioMixerVolume("Music", volume);
    }

    private void SetSfxVolume(float volume)
    {
        SetAudioMixerVolume("Sfx", volume);
    }
}
