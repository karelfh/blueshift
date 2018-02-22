using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    public Sound[] music;

    private AudioSource musicSource;
    private AudioSource soundSource;


    private void Start() {
        soundSource = GameObject.Find("Audio/Sounds").GetComponent<AudioSource>();
        musicSource = GameObject.Find("Audio/Music").GetComponent<AudioSource>();
    }

    private void OnLevelWasLoaded(int level) {
        if (level == 1) {
            PlayMusic("Menu");
        }
        if (level == 5) {
            PlayMusic("Theme");
        }
    }

    public void PlayMusic(string name) {
        foreach (Sound sound in music) {
            if (sound.name == name) {
                musicSource.clip = sound.clip;
                musicSource.Play();
            }
        }
    }

    public void PlaySound(string name) {
        foreach (Sound sound in sounds) {
            if (sound.name == name) {
                soundSource.clip = sound.clip;
                soundSource.Play();
            }
        }
    }

}
