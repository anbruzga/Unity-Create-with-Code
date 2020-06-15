using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    public float leftLimit = -39;
    public float bottomLimit = 0;

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (leftLimit > transform.position.x )
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }

    }
}
