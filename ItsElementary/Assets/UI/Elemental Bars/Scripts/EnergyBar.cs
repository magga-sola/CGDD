
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class EnergyBar : MonoBehaviour
{
    public static PlayerController instance;
    public Color disabledColor;
    public Color enabledColor;

    public Element elementalMode;

    public int startingHealth;
    public int maxHealth;

    
    public Slider slider;
    public Image fillImage;
    bool isActive;

    bool isHurtingFromStronger = false;
    float speedFromStronger = 6f;
    float durationFromStronger = 0.6f;

    bool isHurtingFromSame = false;
    float speedFromSame = 3.5f;
    float durationFromSame = 0.3f;

    bool isHurtingFromWeak = false;
    float speedFromWeak = 1.5f;
    float durationFromWeak = 0.15f;

    Color hurtingColor = new(1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isHurtingFromWeak)
        {
            var currColor = isActive ? enabledColor : disabledColor;
            fillImage.color = Color.Lerp(currColor, hurtingColor, Mathf.Repeat(Time.time * speedFromWeak, 1));
        }
        if (isHurtingFromSame)
        {
            var currColor = isActive ? enabledColor : disabledColor;
            fillImage.color = Color.Lerp(currColor, hurtingColor, Mathf.Repeat(Time.time * speedFromSame, 1));
        }
        if (isHurtingFromStronger)
        {
            var currColor = isActive ? enabledColor : disabledColor;
            fillImage.color = Color.Lerp(currColor, hurtingColor, Mathf.Repeat(Time.time * speedFromStronger, 1));
        }
    }

    public void EnableMode()
    {
        isActive = true;
        fillImage.color = enabledColor;
    }

    public void DisableMode()
    {
        isActive = false;
        fillImage.color = disabledColor;
    }

    public void Initialize(int maxHealth, int startingHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = startingHealth;
    }

    public void DecreaseByWeakOpponent()
    {
        TwinkleWhiteFromWeak();
        slider.value -= 7;
    }

    public void DecreaseBySameOpponent()
    {
        TwinkleWhiteFromSame();
        slider.value -= 15;
    }

    // Enemy is stronger than me
    public void DecreaseByStrongOpponent()
    {
        TwinkleWhiteFromStronger();
        slider.value -= 30;
    }

    private void TwinkleWhiteFromWeak()
    {
        isHurtingFromWeak = true;
        StartCoroutine(TwinkleWhite(durationFromWeak, isActive ? enabledColor : disabledColor));
    }

    private void TwinkleWhiteFromSame()
    {
        isHurtingFromSame = true;
        StartCoroutine(TwinkleWhite(durationFromSame, isActive ? enabledColor : disabledColor));
    }

    private void TwinkleWhiteFromStronger()
    {
        isHurtingFromStronger = true;
        StartCoroutine(TwinkleWhite(durationFromStronger, isActive ? enabledColor : disabledColor));
    }

    private IEnumerator TwinkleWhite(float duration, Color prevColor)
    {
        yield return new WaitForSecondsRealtime(duration);
        isHurtingFromStronger = false;
        isHurtingFromSame = false;
        isHurtingFromWeak = false;
        fillImage.color = prevColor;
    }

    public void DecreaseHealthByAttack()
    {
        slider.value -= 2;
    }

    public void IncreaseHealthByOrb()
    {
        slider.value += 30;
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

    public float GetHealth()
    {
        return slider.value;
    }

    public bool IsHealthLow()
    {
        if (slider.value <= 30)
        {
            return true;
        }
        return false;
    }

}
