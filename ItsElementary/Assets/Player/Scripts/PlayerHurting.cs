using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurting : MonoBehaviour
{
    public PlayerController player;
    //public EnemyController enemy;
    public GameManager.Element element;

    public GameObject enemyProjectile;
    public ElementalBars elementalBars;

    private GameManager.Element playerElement;
    private EnergyBar healthbar;

    void Update()
    {
        
    }
    int mod(int x, int p)
    {
        return (x%p + p)%p; 
    }

    public void HitByEnemyProjectile(GameManager.Element projectileElement)
    {
        playerElement = player.elementalMode; 
        healthbar = elementalBars.GetBarByElement(playerElement);

        Debug.Log("projectile element" + projectileElement);
        Debug.Log("player element" + playerElement);
        
        if (healthbar) 
        {
            if ((GameManager.Element)(mod(((int)projectileElement + 1),3)) == playerElement)
            {
                Debug.Log("hit by: STRONG");
                healthbar.DecreaseByStrongElement();
                
                //50
            }
            else if ((GameManager.Element)(mod(((int)projectileElement - 1),3)) == playerElement)
            {
                Debug.Log("hit by: WEAK");
                healthbar.DecreaseByWeakElement();
                //20
            }
            else if (projectileElement == playerElement)
            {
                Debug.Log("hit by: SAME");
                healthbar.DecreaseBySameElement();
                //34

            }
        }
        
    }

}

//IncreaseHealthByOrb

/////
