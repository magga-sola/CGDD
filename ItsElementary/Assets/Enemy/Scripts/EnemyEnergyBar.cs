using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class EnemyEnergyBar : MonoBehaviour
{

    public Element elementalMode;

    public int startingHealth;
    public int maxHealth;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(int maxHealth, int startingHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = startingHealth;
    }

    public void DecreaseByWeakOpponent()
    {
        slider.value -= 20;
    }

    public void DecreaseBySameOpponent()
    {
        slider.value -= 34;
    }

    public void DecreaseByStrongOpponent()
    {
        slider.value -= 50;
    }

    public bool IsHealthFinished()
    {
        if (slider.value <= 0)
        {
            return true;
        }
        return false;
    }
}
