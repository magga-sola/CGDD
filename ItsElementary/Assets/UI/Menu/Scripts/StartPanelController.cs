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
    }

    public void HideStartScreen()
    {
        startPanel.SetActive(false);
        gameManager.StartGame(false);
    }
}
