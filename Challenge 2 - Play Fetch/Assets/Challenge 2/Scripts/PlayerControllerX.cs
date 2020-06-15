using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private const float automaticShootStartsAfter = 1000f;
    
    private float automaticShootStartTime; 
    private void Start()
    {
        // start time + const
        automaticShootStartTime = Time.time + automaticShootStartsAfter;

    }
    void Update()
    {
        if (Time.time > automaticShootStartTime)
        {    // shoot automatic dogs
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            }
        }
        // On spacebar press, send dog
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
