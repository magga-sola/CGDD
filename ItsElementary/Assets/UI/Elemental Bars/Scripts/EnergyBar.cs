
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
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

    public void InitializeHealth(int maxHealth, int startingHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = startingHealth;
    }

    public void DecreaseHealthByAttack()
    {
        // TODO: Logic for death/empty health?
        slider.value -= 2;
    }

    public void IncreaseHealthByOrb()
    {
        slider.value += 10;
    }

    public bool IsHealthFinished()
    {
        if(slider.value <= 0) {
            return true;
        }
        return false;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

}
