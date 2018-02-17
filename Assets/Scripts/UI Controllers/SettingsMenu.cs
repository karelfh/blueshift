using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

    private AudioMixer audioMixer;
    private Slider masterVolumeSlider;
    private Slider effectsVolumeSlider;
    private Slider musicVolumeSlider;
    private Slider soundOnOffSlider;


    private void Awake() {
        masterVolumeSlider = GameObject.Find("Master Volume/Slider").gameObject.GetComponent<Slider>();
        effectsVolumeSlider = GameObject.Find("Effects Volume/Slider").gameObject.GetComponent<Slider>();
        musicVolumeSlider = GameObject.Find("Music Volume/Slider").gameObject.GetComponent<Slider>();
        soundOnOffSlider = GameObject.Find("Sound On Off/Slider").gameObject.GetComponent<Slider>();
    }

    private void Start() {
        masterVolumeSlider.value = PlayerSettings.GetMasterVolume();
        effectsVolumeSlider.value = PlayerSettings.GetEffectsVolume();
        musicVolumeSlider.value = PlayerSettings.GetMusicVolume();
        soundOnOffSlider.value = PlayerSettings.GetSoundOnOff();
    }

    public void SaveSettings() {
        PlayerSettings.SetMasterVolume(masterVolumeSlider.value);
        PlayerSettings.SetEffectsVolume(effectsVolumeSlider.value);
        PlayerSettings.SetMuicVolume(musicVolumeSlider.value);
        PlayerSettings.SetSoundOnOff((int)soundOnOffSlider.value);
    }

}
