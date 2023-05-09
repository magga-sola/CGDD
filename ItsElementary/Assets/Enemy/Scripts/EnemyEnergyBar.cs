using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class EnemyEnergyBar : MonoBehaviour
{

    public Element elementalMode;

    public int startingHealth;
    public int maxHealth;
    public Slider slider;

    public List<Color> colors;
    public Image fillImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(Element element, int maxHealth, int startingHealth)
    {
        elementalMode = element;
        slider.maxValue = maxHealth;
        slider.value = startingHealth;
        fillImage.color = colors[(int)element];
    }

    public void DecreaseByWeakOpponent()
    {
        slider.value -= 9;
    }

    public void DecreaseBySameOpponent()
    {
        slider.value -= 17;
    }

    public void DecreaseByStrongOpponent()
    {
        slider.value -= 34;
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
