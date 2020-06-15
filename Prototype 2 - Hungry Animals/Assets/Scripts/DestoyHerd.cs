using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyHerd : MonoBehaviour
{
    public float bottomBound = -15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= bottomBound)
        {
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }
    }
}
