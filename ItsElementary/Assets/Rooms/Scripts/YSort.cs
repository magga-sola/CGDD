using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSort : MonoBehaviour
{
    //private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sortingOrder = - (int) (transform.position.y * 100);
        
    }


}


    // void CheckRenderer()
    // {
    //     //Check that the GameObject you select in the hierarchy has a SpriteRenderer component
    //     if (Selection.activeGameObject.GetComponent<SpriteRenderer>())
    //     {
    //         //Fetch the SpriteRenderer from the selected GameObject
    //         rend = Selection.activeGameObject.GetComponent<SpriteRenderer>();
    //         //Change the sorting layer to the name you specify in the TextField
    //         //Changes to Default if the name you enter doesn't exist
    //         rend.sortingLayerName = m_Name.stringValue;
    //         //Change the order (or priority) of the layer
    //         rend.sortingOrder = m_Order.intValue;
    //     }
    // }