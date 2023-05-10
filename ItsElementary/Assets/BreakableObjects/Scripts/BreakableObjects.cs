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
    public bool isBroken;
    public HealingOrb healingorbcontroller;
    public GameObject healingOrb;




    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = elementArray[(5*(int)element) + (int)size];

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Projectile"))
        {
            isBroken = true;
            spriteRenderer.sprite = brokenArray[(5*(int)element) + (int)size];
            //drop health orb of elemental type
            //healingorbcontroller.element = element;
            //GameObject healingOrbClone = Instantiate(healingOrb);
            //healingOrbClone.transform.position = transform.position;

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
