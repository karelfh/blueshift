using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {

    [Tooltip("Main Audio Mixer to rule them all.")]
    [SerializeField] private AudioMixer masterAudioMixer;
    [SerializeField] private AudioMixerGroup effectsMixerGroup;

    public Sound[] sounds;

    private GameObject soundObject;


    private void Awake() {
        soundObject = new GameObject() {
            name = "Sounds"
        };
        soundObject.transform.SetParent(transform);
    }

    private void Start() {
        GenerateSounds();
    }

    public void PlaySound(string name) {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);

        if (s == null) {
            Debug.LogWarning("Sound: " + s.name + " not found!");
            return;
        }

        s.source.Play();
    }

    private void GenerateSounds() {
        foreach (Sound sound in sounds) {
            sound.source = soundObject.AddComponent<AudioSource>();

            sound.source.clip = sound.clip;
            sound.source.loop = sound.loop;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;

            sound.source.outputAudioMixerGroup = effectsMixerGroup;
            masterAudioMixer.SetFloat("Effects Volume", PlayerSettings.GetEffectsVolume());
        }
    }
}