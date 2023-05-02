
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Element
    {
        Fire,
        Water,
        Earth
    }

    PlayerController player;
    public bool gameOver;
    public int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
