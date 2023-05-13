
using UnityEngine;

public class ElementalBars : MonoBehaviour
{
    
    public PlayerController player;

    public EnergyBar fireBar;
    public EnergyBar waterBar;
    public EnergyBar earthBar;

    public GameManager.Element currentElement;


    // Start is called before the first frame update
    void Start()
    {
        fireBar.Initialize(100, 50);
        waterBar.Initialize(100, 50);
        earthBar.Initialize(100, 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsHealthFinishedInElement(GameManager.Element element)
    {
        switch (element)
        {
            case GameManager.Element.Fire:
                return fireBar.IsHealthFinished();
            case GameManager.Element.Water:
                return waterBar.IsHealthFinished();
            case GameManager.Element.Earth:
                return earthBar.IsHealthFinished();
        }

        return false;
    }

    public void SetElementalMode(GameManager.Element element)
    {
        switch (element)
        {
            case GameManager.Element.Fire:
                fireBar.EnableMode(); // Enable fire
                waterBar.DisableMode();
                earthBar.DisableMode();
                break;
            case GameManager.Element.Water:
                fireBar.DisableMode();
                waterBar.EnableMode(); // Enable water
                earthBar.DisableMode();
                break;
            case GameManager.Element.Earth:
                fireBar.DisableMode();
                waterBar.DisableMode();
                earthBar.EnableMode(); // Enable earth
                break;
        }
    }

    public void RestartHealth()
    {
        fireBar.Initialize(100, 50);
        waterBar.Initialize(100, 50);
        earthBar.Initialize(100, 50);
    }

    public void RestartHealthBeginning()
    {
        fireBar.Initialize(100, 70);
        waterBar.Initialize(100, 70);
        earthBar.Initialize(100, 70);
    }

    public EnergyBar GetBarByElement(GameManager.Element element)
    {
        switch (element)
        {
            case GameManager.Element.Fire:
                return fireBar;
            case GameManager.Element.Water:
                return waterBar;
            case GameManager.Element.Earth:
                return earthBar;
        }

        return fireBar;
    }
}
