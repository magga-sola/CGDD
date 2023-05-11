using UnityEngine;

public class PlayerHealing : MonoBehaviour
{
    public PlayerController player;
    public EnemyController enemy;

    public GameObject healingOrb;
    public ElementalBars elementalBars;
    [SerializeField] private AudioSource healingSoundEffect;
    
    void Update()
    {
        
    }

    public void IncreaseHealthByOrb(GameManager.Element element)
    {
        healingSoundEffect.Play();
        switch (element)
        {
            case GameManager.Element.Fire:
                elementalBars.fireBar.IncreaseHealthByOrb();
                break;
            case GameManager.Element.Water:
                elementalBars.waterBar.IncreaseHealthByOrb();
                break;
            case GameManager.Element.Earth:
                elementalBars.earthBar.IncreaseHealthByOrb();
                break;
        }
    }
}