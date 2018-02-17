using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    private AudioMixer audioMixer;


    private void Awake() {
        audioMixer = Resources.Load("Audio/Master Mixer", typeof(AudioMixer)) as AudioMixer;

        foreach (Sound sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            // TODO: Set output to audio mixer group.

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) {
            return;
        }
        
        s.source.Play();
    }

}
