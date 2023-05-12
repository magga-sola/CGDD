using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource introMusic;

    public AudioSource loopMusic;
    AudioClip m_AudioClip;
    public bool Play;

    public bool introDone;
    // Start is called before the first frame update
    void Start()
    {
        if (introMusic != null)
        {
            introMusic.Play();
            loopMusic.PlayDelayed((float)(introMusic.clip.length - 0.1));
            introDone = true;
        } else 
        {
            loopMusic.Play();
        }
        
    }

    void StartMusic()
    {

    }


    void PauseMusic()
    {
        if (introMusic != null && !introDone)
        {
            introMusic.Pause();
        } else 
        {
            loopMusic.Pause();
        }
        

    }

    // Update is called once per frame

        void Update()
    { 
        if (!Play)
        {
            PauseMusic();
        }
    
    }
}
