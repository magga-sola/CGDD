
using UnityEngine;

public class ExitRoomScript : MonoBehaviour
{
    //public bool isTutorial = false;
    public bool isBossKilled = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        /*print("trigger!!");
        if(isTutorial)
        {
            GameManager.instance.startPanel.ShowStartScreen();
        }*/
        if (col.gameObject.name == "Player" && isBossKilled == true)
        {
            GameManager.instance.GoToNextLevel();
        }
    }
}
