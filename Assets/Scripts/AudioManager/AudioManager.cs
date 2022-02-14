using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SoundPiece[] sounds;

    public void PlaySound(int soundIndex)
    {
        
        AudioSource sound = gameObject.AddComponent<AudioSource>();
        sound.clip = sounds[soundIndex].clip;

        sound.volume = sounds[soundIndex].volume;
        sound.loop = sounds[soundIndex].loop;
    }
}
