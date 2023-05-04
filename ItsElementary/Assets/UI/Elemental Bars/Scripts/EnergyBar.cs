
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class EnergyBar : MonoBehaviour
{
    public Color disabledColor;
    public Color enabledColor;

    public Element elementalMode;

    public int startingHealth;
    public int maxHealth;
    public Slider slider;
    public Image fillImage;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableMode()
    {
        fillImage.color = enabledColor;
    }

    public void DisableMode()
    {
        fillImage.color = disabledColor;
    }

    public void Initialize(int maxHealth, int startingHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = startingHealth;
    }

    public void DecreaseHealthByAttack()
    {
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
