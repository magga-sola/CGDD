using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Explosion : MonoBehaviour
{
    public Color[] colors;
    public Animator animator;
    public GameManager.Element element;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = colors[(int)element];
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("Exploded") && gameObject.name!= "Explosion")
        {
            Destroy(gameObject);
        }
    }
}
