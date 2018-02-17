using UnityEngine;
using UnityEngine.Audio;

public class PlayerSettings : SingletonMonoBehaviour<PlayerSettings> {

    private const string MASTER_VOLUME = "Master Volume";
    private const string EFFECTS_VOLUME = "Effects Volume";
    private const string MUSIC_VOLUME = "Music Volume";
    private const string SOUND_ON_OFF = "Sound On Off";

    #region Sets
    #region Volume
    public static void SetMasterVolume(float volume) {
        if (volume > -80f && volume < 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME, volume);
        } else {
            Debug.LogError("Master Volume out of range (-80 to 1)!");
        }
    }

    public static void SetEffectsVolume(float volume) {
        if (volume > -80f && volume < 1f) {
            PlayerPrefs.SetFloat(EFFECTS_VOLUME, volume);
        } else {
            Debug.LogError("Effects Volume out of range (-80 to 1)!");
        }
    }

    public static void SetMuicVolume(float volume) {
        if (volume > -80f && volume < 1f) {
            PlayerPrefs.SetFloat(MUSIC_VOLUME, volume);
        } else {
            Debug.LogError("Music Volume out of range (-80 to 1)!");
        }
    }
    #endregion
    #region Sound On/Off
    public static void SetSoundOnOff(int boolean) {
        if (boolean == 1) {
            PlayerPrefs.SetInt(SOUND_ON_OFF, boolean);
        }
    }
    #endregion
    #endregion


    #region Gets
    #region Volume
    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME);
    }

    public static float GetEffectsVolume() {
        return PlayerPrefs.GetFloat(EFFECTS_VOLUME);
    }

    public static float GetMusicVolume() {
        return PlayerPrefs.GetFloat(MUSIC_VOLUME);
    }
    #endregion
    #region Sound On/Off
    public static int GetSoundOnOff() {
        return PlayerPrefs.GetInt(SOUND_ON_OFF);
    }
    #endregion
    #endregion
}
