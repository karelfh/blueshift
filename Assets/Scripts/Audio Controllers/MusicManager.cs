using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : SingletonMonoBehaviour<MusicManager> {

    [Tooltip("Main Audio Mixer to rule them all.")]
    [SerializeField] private AudioMixer masterAudioMixer;
    [SerializeField] private AudioMixerGroup musicMixerGroup;   

    public Sound[] music;

    private GameObject musicObject;  


    private void Awake() {
        musicObject = new GameObject() {
            name = "Music"
        };
        musicObject.transform.SetParent(transform);
    }

    private void Start() {
        GenerateMusic();
    }

    public void PlayMusic(string name) {
        Sound m = System.Array.Find(music, music => music.name == name);

        if (m == null) {
            Debug.LogWarning("Music: " + m.name + " not found!");
            return;
        }

        m.source.Play();
    }

    public void StopAudio(string name) {
        Sound m = System.Array.Find(music, sound => sound.name == name);
        m.source.Stop();
    }

    private void GenerateMusic() {
        foreach (Sound sound in music) {
            sound.source = musicObject.AddComponent<AudioSource>();

            sound.source.clip = sound.clip;
            sound.source.loop = sound.loop;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;

            sound.source.outputAudioMixerGroup = musicMixerGroup;
            masterAudioMixer.SetFloat("Music Volume", PlayerSettings.GetMusicVolume());
        }
    }
}
