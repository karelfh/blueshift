using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "New Sound", menuName = "Audio/Sound", order = 1)]
public class Sound : ScriptableObject {

    public new string name;
    public string handle;

    public AudioClip clip;

    public FloatReference volume;
    public FloatReference pitch;

    public bool loop;

}
