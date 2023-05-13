using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurting : MonoBehaviour
{
    public PlayerController player;
    public GameObject enemyProjectile;
    public ElementalBars elementalBars;
    private GameManager.Element playerElement;
    private EnergyBar healthbar;
    private string[] animatorParameters = {"Red Cracked", "Green Cracked", "Blue Cracked"};
    void Start()
    {
        player = GameManager.instance.player;

    }
    void Update()
    {
        healthbar = elementalBars.GetBarByElement(player.elementalMode);
        if (!healthbar.IsHealthLow() && player.circleAnimator.GetBool(animatorParameters[(int)player.elementalMode]))
        {
            player.circleAnimator.SetBool(animatorParameters[(int)player.elementalMode],false);
        }
        else if (healthbar.IsHealthLow() && !player.circleAnimator.GetBool(animatorParameters[(int)player.elementalMode]))
        {
            player.circleAnimator.SetBool(animatorParameters[(int)player.elementalMode],true);
        }
    }

    int Mod(int x, int p)
    {
        return (x%p + p)%p; 
    }

    public void HitByEnemyProjectile(GameManager.Element projectileElement)
    {
        playerElement = player.elementalMode; 
        healthbar = elementalBars.GetBarByElement(playerElement);

        if (healthbar) 
        {
            if ((GameManager.Element)Mod((int)projectileElement + 1,3) == playerElement)
            {
                healthbar.DecreaseByStrongOpponent();
            }
            else if ((GameManager.Element)Mod((int)projectileElement - 1,3) == playerElement)
            {
                healthbar.DecreaseByWeakOpponent();
            }
            else if (projectileElement == playerElement)
            {
                healthbar.DecreaseBySameOpponent();
            }
        }
        
    }

}
