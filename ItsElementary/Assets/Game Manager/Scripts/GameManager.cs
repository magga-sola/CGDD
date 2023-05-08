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
        if(level == 1)
        {
            SceneManager.LoadScene("RoomsScene");
            player.transform.position = new Vector3((float)-30.7800007, (float)43.3499985, 0);
        }
        if(level == 2)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }

    public void GameOver(){
        gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}