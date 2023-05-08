using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(animator.GetBool("Exploded"));
        if (animator.GetBool("Exploded") && gameObject.name!= "Explosion")
        {
            Destroy(gameObject);
        }
    }
}
