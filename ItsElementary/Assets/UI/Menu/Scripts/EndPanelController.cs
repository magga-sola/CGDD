using UnityEngine;

public class EndPanelController : MonoBehaviour
{
    public GameObject endPanel;
    public GameObject gameOverScreen;
    public GameObject gameWonScreen;
    public StartPanelController startPanelController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowGameOverScreen()
    {
        endPanel.SetActive(true);
        gameOverScreen.SetActive(true);
        gameWonScreen.SetActive(false);
        AudioSource music = GameManager.instance.panelAudioSource;
        Debug.Log("music: "+ music);
        PauseGame(music);
    }

    public void ShowGameWonScreen()
    {
        endPanel.SetActive(true);
        gameWonScreen.SetActive(true);
        AudioSource music = GameManager.instance.panelAudioSource;
        PauseGame(music);
    }

    // After game over
    public void StartOverGame()
    {
        GameManager.instance.StartGame(false);
        HideEndScreen();
        UnPauseGame();
    }

    // After game over
    public void RestartLevel()
    {
        GameManager.instance.RestartLevel();
        HideEndScreen();
        UnPauseGame();
    }

    // After game won
    public void PlayAgain()
    {
        GameManager.instance.StartGame(true);
        HideEndScreen();
        UnPauseGame();
    }

    public void HideEndScreen()
    {
        endPanel.SetActive(false); ;
        gameOverScreen.SetActive(false);
        gameWonScreen.SetActive(false);
    }

    public void PauseGame(AudioSource music)
    {
        foreach (AudioSource i in FindObjectsOfType<AudioSource>())
        {
            if (i != music)
            {
                Debug.Log(i.clip);
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
