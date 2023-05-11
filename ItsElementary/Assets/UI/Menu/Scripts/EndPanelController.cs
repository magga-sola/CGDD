using UnityEngine;

public class EndPanelController : MonoBehaviour
{
    public GameObject endPanel;
    public GameObject gameOverScreen;
    public GameObject gameWonScreen;
    public GameManager gameManager;

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
        PauseGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }

    public void ShowGameWonScreen()
    {
        endPanel.SetActive(true);
        gameWonScreen.SetActive(true);
        PauseGame();
    }

    // After game over
    public void StartOverGame()
    {
        gameManager.StartGame();
        HideEndScreen();
        UnPauseGame();
    }

    // After game over
    public void RestartLevel()
    {
        gameManager.RestartLevel();
        HideEndScreen();
        UnPauseGame();
    }

    // After game won
    public void PlayAgain()
    {
        HideEndScreen();
        gameManager.PlayAgain();
        UnPauseGame();
    }

    public void HideEndScreen()
    {
        endPanel.SetActive(false); ;
        gameOverScreen.SetActive(false);
        gameWonScreen.SetActive(false);
    }
}