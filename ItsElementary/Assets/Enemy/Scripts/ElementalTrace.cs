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
    }
    
    public void SetElement(Element element)
    {
        spriteRenderer.sprite = spriteArray[(int)element];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
