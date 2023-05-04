
using UnityEngine;
using UnityEngine.SceneManagement;
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
        fireBar.InitializeHealth(100, 50);
        waterBar.InitializeHealth(100, 50);
        earthBar.InitializeHealth(100, 50);
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
        Debug.Log("Changing mode to: " + element.ToString());
    }

    int mod(int x, int p)
    {
        return (x%p + p)%p; 
    }
    public void HitByElement(GameManager.Element projectileElement)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
