using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int startingHealth = 2;
    public int maxHealth = 10;
    public Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStartingHealth(int maxHealth, int startingHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = startingHealth;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

}
