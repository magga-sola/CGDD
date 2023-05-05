using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurting : MonoBehaviour
{
    public PlayerController player;
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
                healthbar.DecreaseByStrongOpponent();
                //50
            }
            else if ((GameManager.Element)(mod(((int)projectileElement - 1),3)) == playerElement)
            {
                healthbar.DecreaseByWeakOpponent();
            }
            else if (projectileElement == playerElement)
            {
                healthbar.DecreaseBySameOpponent();
                //34
            }
        }
        
    }

}
