﻿using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : SingletonMonoBehaviour<AudioManager> {

    [Tooltip("Main Audio Mixer to rule them all.")]
    [SerializeField] private AudioMixer masterAudioMixer;

    //[Header("Sound Effects Settings")]
    //[SerializeField] private AudioMixerGroup effectsMixerGroup;
    //public Sound[] sounds;

    [Header("Music Settings")]
    [SerializeField] private AudioMixerGroup musicMixerGroup;   
    public Sound[] music;

    private GameObject audioObject;
    //private GameObject soundObject;
    private GameObject musicObject;  


    private void Awake() {
        audioObject = new GameObject() {
            name = "Audio"
        };
        audioObject.AddComponent<DDOL>();

        //soundObject = new GameObject() {
        //    name = "Sounds"
        //};
        //soundObject.transform.SetParent(audioObject.transform);

        musicObject = new GameObject() {
            name = "Music"
        };
        musicObject.transform.SetParent(audioObject.transform);
    }

    private void Start() {
        //GenerateSounds();
        GenerateMusic();
    }

    private void OnLevelWasLoaded(int level) {
        if (level == 1) {
            PlayMusic("Menu");
        }
        if (level == 5) {
            PlayMusic("Theme");
            StopAudio("Menu");
        }
    }

    /*
    public void PlaySound(string name) {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);

        if (s == null) {
            Debug.LogWarning("Sound: " + s.name + " not found!");
            return;
        }

        s.source.Play();
    }
    */

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

            sound.source.outputAudioMixerGroup = musicMixerGroup;
            masterAudioMixer.SetFloat("Music Volume", PlayerSettings.GetMusicVolume());
        }
    }

    /*
    private void GenerateSounds() {
        foreach (Sound sound in sounds) {
            sound.source = soundObject.AddComponent<AudioSource>();

            sound.source.clip = sound.clip;
            sound.source.loop = sound.loop;

            sound.source.outputAudioMixerGroup = effectsMixerGroup;
            masterAudioMixer.SetFloat("Effects Volume", PlayerSettings.GetEffectsVolume());
        }
    }
    */
}
