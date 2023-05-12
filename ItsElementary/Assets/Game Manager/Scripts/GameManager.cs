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

    (AudioClip, AudioClip) clips;
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
        if(startGame)
        {
            startPanel.ShowStartScreen();
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
            "7FinalRoomBoss" // 7
        };
        positions = new List<Vector3>()
        {
            new Vector3((float)10.2200003,(float)-0.300000012,1), // 0
            new Vector3((float)-6.8,(float)-0.81,0), // 1
            new Vector3((float)-9.5,(float)50.2999992,0), // 2
            new Vector3((float)-5.63847637,(float)-0.879456997,0), // 3
            new Vector3((float)-29.7999992,(float)42.7999992,0), // 4
            new Vector3((float)-5.5, (float)-0.699999988, 0), // 5
            new Vector3(-0.460000008f,3.68000007f,0), // 6
            new Vector3((float)-9.63000011,(float)-1.47000003, 0), // 7
        };
    }

    public void StartGame()
    {
        level = 0;
        player.RestartPlayer();
        player.isPaused = false;
        StartLevel(level);
        gameOver = false;
    }

    public void PlayAgain()
    {
        startPanel.ShowStartScreen();
        level = 0;
        player.RestartPlayer();
        player.isPaused = false;
        gameOver = false;
        StartLevel(level);
    }

    public void RestartLevel()
    {
        if(level % 2 != 0)
        {
            level--;
        }
        player.RestartPlayer();
        player.isPaused = false;
        StartLevel(level);
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    // TODO call function when player kills boss :)
    public void GameWon()
    {
        endPanel.ShowGameWonScreen();

    }

    public void GoToNextLevel()
    {
        level++;
        SceneManager.LoadScene(scenes[level]);
        player.transform.position = positions[level];

        clips = backgroundMusic.LoadMusicByScene(level);

        audioSource1.clip = clips.Item1;
        audioSource2.clip = clips.Item2;

        backgroundMusic.PlayMusic(audioSource1, audioSource2);

    }

    public void PlayerDied(){
        gameOver = false;
        endPanel.ShowGameOverScreen();
        player.isPaused = true;
        backgroundMusic.PauseMusic(audioSource1, audioSource2);
    }

    public void StartLevel(int level)
    {
        player.transform.position = positions[level];
        SceneManager.LoadScene(scenes[level]);
        clips = backgroundMusic.LoadMusicByScene(level);

        audioSource1.clip = clips.Item1;
        audioSource2.clip = clips.Item2;
        
        Debug.Log(audioSource1 + " and "+ audioSource2);
        backgroundMusic.PlayMusic(audioSource1, audioSource2);
        
    }
}