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
    }

    public void ShowGameWonScreen()
    {
        endPanel.SetActive(true);
        gameWonScreen.SetActive(true);
    }

    // After game over
    public void StartOverGame()
    {
        gameManager.StartGame();
        HideEndScreen();
    }

    // After game over
    public void RestartLevel()
    {
        gameManager.RestartLevel();
        HideEndScreen();
    }

    // After game won
    public void PlayAgain()
    {
        HideEndScreen();
        gameManager.PlayAgain();
    }

    public void HideEndScreen()
    {
        endPanel.SetActive(false); ;
        gameOverScreen.SetActive(false);
        gameWonScreen.SetActive(false);
    }
}
