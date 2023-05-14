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

    public Music StartMusic;
    public Music WinMusic;
    public Music LoseMusic;
    void Start()
    {
        scenes = gameManager.scenes;
        introDone = false;
        
    }

    public (AudioClip, AudioClip) LoadMusicByScene(int level)
    {
        
        return (musicByScene[level].introMusic, musicByScene[level].loopMusic);
        
    }


    public void PlayMusic(AudioSource loopMusic, AudioSource introMusic = null)
    {
        if (introMusic != null && introMusic.clip != null)
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

    public void PauseMusic(AudioSource loopMusic, AudioSource introMusic = null)
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
