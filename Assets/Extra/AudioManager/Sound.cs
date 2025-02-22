using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public bool loop;

    [Range(0,1f)]
    public float volumen;
    [Range(0, 3f)]
    public float pitch;
    
    [HideInInspector]
    public AudioSource source;
}
