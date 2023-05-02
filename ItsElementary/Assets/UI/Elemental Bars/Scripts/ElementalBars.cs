using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalBars : MonoBehaviour
{
    public PlayerController.Element currentElement;

    public EnergyBar fireBar;
    public EnergyBar waterBar;
    public EnergyBar earthBar;

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
}
