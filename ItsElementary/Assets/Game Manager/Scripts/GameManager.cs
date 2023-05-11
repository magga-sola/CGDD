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
    private List<string> scenes;
    private List<Vector3> positions;
    public bool startGame = true;

    public MenuController menu;


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
            menu.ShowStartScreen();
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
            new Vector3((float)5.0999999,(float)-0.300000012,0), // 0
            new Vector3((float)-5.51999998,(float)-0.349999994, 0), // 1
            new Vector3((float)-9.5,(float)50.2999992,0), // 2
            new Vector3((float)-5.63847637,(float)-0.879456997,0), // 3
            new Vector3((float)-29.7999992,(float)42.7999992,0), // 4
            new Vector3((float)-5.5, (float)-0.699999988, 0), // 5
            new Vector3((float)-0.504999995,(float)21.6369991,0), // 6
            new Vector3((float)-9.63000011,(float)-1.47000003, 0), // 7
        };
    }

    public void StartGame()
    {
        player.RestartPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        //Restart();
    }
    /*
    void Restart()
    {
        if (SceneManager.GetActiveScene().name == "EndScreen")
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("SampleScene");

            }
        }
    }
    */

    public void GoToNextLevel()
    {
        level++;
        Debug.Log("level:" + level);
        Debug.Log("scenes:" + scenes[level]);
        Debug.Log("positions:" + positions[level]);
        SceneManager.LoadScene(scenes[level]);
        player.transform.position = positions[level];
    }

    public void PlayerDied(){
        gameOver = false;
        StartLevel(level);
    }

    public void StartLevel(int level)
    {
        SceneManager.LoadScene(scenes[level]);
        player.transform.position = positions[level];
    }
}