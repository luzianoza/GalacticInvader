using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer _audioMix;
    
    public void SetVolume(float vol)
    {
        _audioMix.SetFloat("volume", vol);
    }
}
