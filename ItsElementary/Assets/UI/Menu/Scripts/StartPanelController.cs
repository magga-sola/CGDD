using UnityEngine;

public class StartPanelController : MonoBehaviour
{
    public GameObject startPanel;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowStartScreen()
    {
        startPanel.SetActive(true);
        PauseGame();
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        gameManager.StartGame(false);
        UnPauseGame();
    }
    public void StartTutorial()
    {
        startPanel.SetActive(false);
        gameManager.StartTutorial();
        UnPauseGame();
    }

    public void PauseGame()
    {
        foreach (AudioSource i in GameObject.FindObjectsOfType<AudioSource>())
        {
            //if (i != music)
            //{
                i.volume = i.volume > 0 ? 0 : 1; // or just i.voume = 0 or something    
            //}
        }

        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        foreach (AudioSource i in GameObject.FindObjectsOfType<AudioSource>())
        {
            //if (i != music)
            //{
                i.volume = i.volume > 0 ? 0 : 1; // or just i.voume = 0 or something    
            //}
        }

        Time.timeScale = 1;
    }
}
