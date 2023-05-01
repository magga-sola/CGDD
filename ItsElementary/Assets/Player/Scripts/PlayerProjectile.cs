using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerController.element element;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    void Start()
    {
        element = playerController.elementalMode;
        spriteRenderer.sprite = spriteArray[(int)element];
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
