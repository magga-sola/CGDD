
using UnityEngine;

public class ExitRoomScript : MonoBehaviour
{
    public bool isBossKilled = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && isBossKilled == true)
        {
            GameManager.instance.GoToNextLevel();
        }
    }
}
