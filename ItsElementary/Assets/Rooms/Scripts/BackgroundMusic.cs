using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource introMusic;

    public AudioSource loopMusic;
    AudioClip m_AudioClip;
    bool m_Play;
    bool m_ToggleChange;
    // Start is called before the first frame update
    void Start()
    {
        if (introMusic != null)
        {
            introMusic.Play();
            loopMusic.PlayDelayed((float)(introMusic.clip.length - 0.1));
        } else 
        {
            loopMusic.Play();
        }

        
    }

    // Update is called once per frame

        void Update()
    { 

    
    }
}
