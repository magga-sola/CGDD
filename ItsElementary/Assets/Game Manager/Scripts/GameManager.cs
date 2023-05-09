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
        gameOver = false;
        scenes = new List<string> ()
        {
            "1FireRoom", // 0
            "2FireRoomBoss", // 1

            "3FireEarthRoom", // 2
            "4FireEarthRoomBoss", // 3

            "5EarthWaterRoom", // 4
            "6EarthWaterRoomBoss", // 5

            "7FinalRoom", // 6
            "8FinalRoomBoss" // 7
        };
        positions = new List<Vector3>()
        {
            new Vector3((float)13.1999998, (float)10.7299995, 0),
            new Vector3((float)-5.51999998,(float)-0.349999994,0),
            new Vector3((float)-13.4899998,(float) 63.1599998, 0),
        };
    }

    // Update is called once per frame
    void Update()
    {
        Restart();
    }

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

    public void GoToNextLevel()
    {
        level++;
        Debug.Log("level:" + level);
        Debug.Log("scenes:" + scenes[level]);
        Debug.Log("positions:" + positions[level]);
        SceneManager.LoadScene(scenes[level]);
        player.transform.position = positions[level];
        /*
        if (level == 2)
        {
            StartLevel2();
        }
        if(level == 3)
        {
            SceneManager.LoadScene("EndScreen");
        }*/
    }

    public void PlayerDied(){
        gameOver = false;

        if(level % 2 != 0)
        {
            level--;
        }

        StartLevel(level);
        /*
        if (level == 1)
        {
            StartLevel1();
        }
        if (level == 2)
        {
            StartLevel2();
        }*/
    }

    public void StartLevel(int level)
    {
        SceneManager.LoadScene(scenes[level]);
        player.transform.position = positions[level];
    }
    /*
    public void StartLevel2()
    {
        SceneManager.LoadScene(scenes[2]);
        player.transform.position = positions[2];
    }*/
}