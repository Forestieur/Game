using UnityEngine.Audio;
using System;
using UnityEngine;

public class Sound_manager : MonoBehaviour
{
    public Sound[] sounds;
 

    [SerializeField]
    public AudioClip enemyHitSound_1;


    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    

    }

  


    public void Play (string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
