using UnityEngine;

[System.Serializable]
public class Sound {

    public string name;

    public AudioClip clip;
    [HideInInspector] public AudioSource source;

    public bool loop;
    public float volume;
    public float pitch;

}
