using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class ElementalTrace : MonoBehaviour
{
    //public Element element;
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer.sprite = spriteArray[(int)element];
    }
    
    public void SetElement(Element element)
    {
        print("element:"+ (int)element);
        spriteRenderer.sprite = spriteArray[(int)element];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
