using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource introMusic;

    public AudioSource loopMusic;
    bool m_Play;
    bool m_ToggleChange;
    // Start is called before the first frame update
    void Start()
    {
        introMusic.Play();
        loopMusic.PlayDelayed((float)5.5);
        
    }

    // Update is called once per frame

        void Update()
    { 

    
    }
}
