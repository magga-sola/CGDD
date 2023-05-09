
using UnityEngine;

public class ExitRoomScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("trigger");
        if (col.gameObject.name == "Player")
        {
            GameManager.instance.GoToNextLevel();
        }
    }
}
