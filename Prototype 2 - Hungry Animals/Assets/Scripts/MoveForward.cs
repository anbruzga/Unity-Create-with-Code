using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    public float speed = 40f;
    public float rotationSpeed = 30f;
    // Start is called before the first frame update

    public GameObject pizza
    {
        set; get;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //MapBorders.DontLeaveMap(this);
        // rotate
        // transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
