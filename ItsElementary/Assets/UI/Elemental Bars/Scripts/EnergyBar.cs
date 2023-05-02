using System.Collections;
using System.Collections.Generic;
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
        float currentValue = slider.value;
        if(currentValue >= 10) {
            slider.value -= 10;
        }
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

}
