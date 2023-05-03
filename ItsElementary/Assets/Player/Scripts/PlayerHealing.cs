using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealing : MonoBehaviour
{
    public PlayerController player;
    public EnemyController enemy;
    //public GameManager.Element element;

    public GameObject healingOrb;
    public ElementalBars elementalBars;
    

    void Update()
    {
        
    }

    public void IncreaseHealthByOrb(GameManager.Element element)
    {
        switch (element)
        {
            case GameManager.Element.Fire:
                elementalBars.fireBar.IncreaseHealthByOrb();
                break;
            case GameManager.Element.Water:
                elementalBars.waterBar.IncreaseHealthByOrb();
                break;
            case GameManager.Element.Earth:
                elementalBars.earthBar.IncreaseHealthByOrb();
                break;
        }
    }


}

//IncreaseHealthByOrb


/////
