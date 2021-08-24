using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public bool loop;
    public bool PlayOnAwake;

    [HideInInspector]
    public AudioSource source;

    [Range(0f, 1f)]
    public float volume;

    [Range(1f, 3f)]
    public float pitch;

    public float time;
}
