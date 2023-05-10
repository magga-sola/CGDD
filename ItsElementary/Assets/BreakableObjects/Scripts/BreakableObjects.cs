using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjects : MonoBehaviour
{
        public enum Size
    {
        Large = 0,
        Big = 1,
        Medium = 2,
        Small = 3,
        Tiny = 4
    }

    public Size size;
    public Sprite[] elementArray;
    public SpriteRenderer spriteRenderer;
    public Sprite[] brokenArray;
    public GameManager.Element element;




    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = elementArray[(int)element + (int)size];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
