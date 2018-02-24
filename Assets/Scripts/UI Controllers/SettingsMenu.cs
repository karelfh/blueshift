using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

    [SerializeField] private AudioMixer masterMixer;

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

        SetMixerVolume();        
    }

    private void SetMixerVolume() {
        if (PlayerSettings.GetSoundOnOff() == 0) {
            masterMixer.SetFloat("Master Volume", -80f);
        } else {
            masterMixer.SetFloat("Master Volume", PlayerSettings.GetMasterVolume());
            masterMixer.SetFloat("Music Volume", PlayerSettings.GetMusicVolume());
            masterMixer.SetFloat("Effects Volume", PlayerSettings.GetEffectsVolume());
        }
    }

}
