using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public static SFXManager instance;
    private AudioSource sfxAudioSource;

 
    public AudioClip[] sfxClips;

    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
            return;
        }

     
        sfxAudioSource = GetComponent<AudioSource>();
        if (sfxAudioSource == null)
        {
            sfxAudioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    
    public void PlaySFX(string clipName)
    {
        
        AudioClip clipToPlay = null;
        foreach (AudioClip clip in sfxClips)
        {
            if (clip.name == clipName)
            {
                clipToPlay = clip;
                break;
            }
        }


        if (clipToPlay != null && sfxAudioSource != null)
        {
            sfxAudioSource.PlayOneShot(clipToPlay);
        }
        else
        {
            Debug.LogWarning("Audio clip dengan nama " + clipName + " tidak ditemukan!");
        }
    }
}   
