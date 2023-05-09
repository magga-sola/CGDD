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
        //player.transform.position = new Vector3((float)-7.0999999, (float)-0.5, 0);
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
            new Vector3((float)13.1999998, (float)10.7299995, 0), // 0
            new Vector3((float)-5.51999998,(float)-0.349999994, 0), // 1
            new Vector3((float)-13.4899998,(float) 63.1599998, 0), // 2
            new Vector3((float)-5.63847637,(float)-0.879456997,0), // 3
            new Vector3((float)-30.7000008,(float)64.0999985,0), // 4
            new Vector3((float)-5.5, (float)-0.699999988, 0), // 5
            new Vector3((float)-0.439999998,(float)3.70000005,0), // 6
            new Vector3((float) 0,(float) 0, 0), // 7
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
    }

    public void PlayerDied(){
        gameOver = false;

        if(level % 2 != 0)
        {
            level--;
        }

        StartLevel(level);
    }

    public void StartLevel(int level)
    {
        SceneManager.LoadScene(scenes[level]);
        player.transform.position = positions[level];
    }
}