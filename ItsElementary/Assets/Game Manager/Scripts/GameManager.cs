using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum Element
    {
        Fire = 0,
        Earth = 1,
        Water = 2
    }

    public PlayerController player;

    public bool gameOver;
    public int level = 0;
    public List<string> scenes;
    private List<Vector3> positions;
    public bool startGame = true;

    public StartPanelController startPanel;
    public EndPanelController endPanel;
    public AudioSource audioSource;
    public MusicManager backgroundMusic;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource panelAudioSource;

    (AudioClip, AudioClip) clips;
    Music panelclips;
    void FixedUpdate()
    {
        
    }

    void Awake()
    {
        if(instance is null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (startGame)
        {
            panelAudioSource.clip = backgroundMusic.StartMusic.loopMusic;
            backgroundMusic.PlayMusic(panelAudioSource);

            player.isPaused = true;
            player.RestartPlayerBeginning();
            startPanel.ShowStartScreen();
            //backgroundMusic.PauseMusic(audioSource1, audioSource2);
        }
        gameOver = false;
        scenes = new List<string> ()
        {
            "0FireRoom", // 0
            "1FireRoomBoss", // 1

            "2FireEarthRoom", // 2
            "3FireEarthRoomBoss", // 3

            "4EarthWaterRoom", // 4
            "5EarthWaterRoomBoss", // 5

            "6FinalRoom", // 6
            "7FinalRoomBoss", // 8
            "-1PlayRoom" // 7
        };
        positions = new List<Vector3>()
        {
            new Vector3(10.2f,-0.3f,1), // 0
            new Vector3(-6.8f,-4.6f,0), // 1
            new Vector3(-9.5f,50.3f,0), // 2
            new Vector3(-5.6f,-0.8f,0), // 3
            new Vector3(-29.8f,42.8f,0), // 4
            new Vector3(-5.5f,-0.7f,0), // 5
            new Vector3(-0.4f,3.7f,0), // 6
            new Vector3(-9.6f,-1.5f, 0), // 7
            new Vector3(-41f, 0, 0), // 8
        };
    }

    // From level 8 (-1)
    public void StartTutorial()
    {
        level = 8;
        player.RestartPlayerBeginning();
        player.isPaused = false;
        backgroundMusic.PauseMusic(panelAudioSource);
        StartLevel(level);
        gameOver = false;
    }

    public void StartPanelMusic(Music panelMusic)
    {
        panelAudioSource.clip = panelMusic.loopMusic;
        backgroundMusic.PlayMusic(panelAudioSource);
    }

    // From level 0
    public void StartGame(bool playAgain)
    {
        if (playAgain)
        {
            StartPanelMusic(backgroundMusic.StartMusic);
            startPanel.ShowStartScreen();
        }
        level = 0;
        // stop Startmenu music
        backgroundMusic.PauseMusic(panelAudioSource);
        player.RestartPlayerBeginning();
        player.isPaused = false;
        StartLevel(level);
        gameOver = false;
    }

    // From start screen
    public void PlayAgain()
    {
        level = 0;
        player.RestartPlayerBeginning();
        player.isPaused = false;
        gameOver = false;
        backgroundMusic.PauseMusic(panelAudioSource);
        StartLevel(level);
    }

    public void RestartLevel()
    {
        if(level % 2 != 0)
        {
            level--;
        }
        if(level == 0)
        {
            player.RestartPlayerBeginning();
        }
        else
        {
            player.RestartPlayer();
        }
        player.isPaused = false;
        backgroundMusic.PauseMusic(panelAudioSource);
        StartLevel(level);
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GameWon()
    {
        backgroundMusic.PauseMusic(audioSource1);
        backgroundMusic.PauseMusic(audioSource2);
        StartPanelMusic(backgroundMusic.WinMusic);
        
    }

    public void GoToNextLevel()
    {
        // If at tutorial
        if(level == scenes.Count - 1)
        {
            level = 0;
            StartPanelMusic(backgroundMusic.StartMusic);
            startPanel.ShowStartScreen();
        }
        else
        {
            level++;

        }
        print("level" + level);
        SceneManager.LoadScene(scenes[level]);
        player.transform.position = positions[level];

        clips = backgroundMusic.LoadMusicByScene(level);

        audioSource1.clip = clips.Item1;
        audioSource2.clip = clips.Item2;

        backgroundMusic.PlayMusic(audioSource1, audioSource2);
    }

    public void PlayerDied(){
        backgroundMusic.PauseMusic(audioSource1);
        backgroundMusic.PauseMusic(audioSource2);

        StartPanelMusic(backgroundMusic.LoseMusic);
        gameOver = false;
        endPanel.ShowGameOverScreen();
        player.isPaused = true;
        

    }

    public void StartLevel(int level)
    {
        SceneManager.LoadScene(scenes[level]);
        player.transform.position = positions[level];
        clips = backgroundMusic.LoadMusicByScene(level);

        audioSource1.clip = clips.Item1;
        audioSource2.clip = clips.Item2;

        backgroundMusic.PlayMusic(audioSource1, audioSource2);        
    }
}