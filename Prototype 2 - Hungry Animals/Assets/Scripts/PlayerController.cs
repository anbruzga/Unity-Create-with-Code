using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 15.0f;

    public float xRange = 24;
    public float zRangeNearEdge = 14;
    public float zRangeFar = 33;

    public GameObject projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        dontLeaveMap();
        shoot();
       
    }

    void dontLeaveMap()
    {
        // does not allow to leave map in X range
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // does not allow to leave map in Z range
        if (transform.position.z < -zRangeNearEdge)
        {
            transform.position = new Vector3(transform.position.x,  transform.position.y, -zRangeNearEdge);
        }
        else if (transform.position.z > zRangeFar)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeFar);
        }
    }


    void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
