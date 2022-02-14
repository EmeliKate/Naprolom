using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundPiece
{
    public string name;

    public AudioClip clip;

    public bool loop;

    [Range(0f, 1f)]
    public float volume;
    
}
