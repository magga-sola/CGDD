using UnityEngine;

public class StartPanelController : MonoBehaviour
{
    public GameObject startPanel;
    public GameManager gameManager;

    AudioSource music;

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
        AudioSource music = GameManager.instance.panelAudioSource;
        PauseGame(music);
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

    public void PauseGame(AudioSource music)
    {
        foreach (AudioSource i in FindObjectsOfType<AudioSource>())
        {
            if (i != music)
            {
                i.volume = i.volume > 0 ? 0 : 1; // or just i.voume = 0 or something    
            }
        }

        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }
}
