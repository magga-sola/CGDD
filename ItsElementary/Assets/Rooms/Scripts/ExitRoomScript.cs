
using UnityEngine;

public class ExitRoomScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            GameManager.instance.GoToNextLevel();
        }
    }
}
