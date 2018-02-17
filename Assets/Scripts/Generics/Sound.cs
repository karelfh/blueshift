using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {

    public string name;

    public AudioClip clip;
    [HideInInspector] public AudioSource source;

    public FloatReference volume;
    public FloatReference pitch;

    public bool loop;

}
