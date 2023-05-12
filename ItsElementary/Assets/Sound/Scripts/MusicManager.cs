using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public GameManager gameManager;
    public Music music;

    List<string> scenes;
    bool introDone;

    
    public List<Music> musicByScene;

    void Start()
    {
        scenes = gameManager.scenes;
        introDone = false;
        
    }

    public (AudioClip, AudioClip) LoadMusicByScene(int level)
    {

        return (musicByScene[level].introMusic, musicByScene[level].loopMusic);
        
    }


    public void PlayMusic(AudioSource introMusic, AudioSource loopMusic)
    {
        if (introMusic.clip != null)
        {
            introMusic.Play();
            loopMusic.PlayDelayed((float)(introMusic.clip.length - 0.1));
            introDone = true;
        } else 
        {
            introDone = true;
            loopMusic.Play();
        }
    }

    public void PauseMusic(AudioSource introMusic, AudioSource loopMusic)
    {
        
        if (introMusic != null && !introDone)
        {
            introMusic.Stop();
        } else 
        {
            loopMusic.Stop();
        }

    }

}
