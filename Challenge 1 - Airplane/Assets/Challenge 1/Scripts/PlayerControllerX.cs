using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float horizontalInput;
    public float verticalInput;
    private float rotatorCoof = 50f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotatorCoof * horizontalInput * Time.deltaTime);

     //   transform.Translate(Vector3.right * speed * verticalInput * Time.deltaTime);
        transform.Rotate(Vector3.right * rotatorCoof * verticalInput * Time.deltaTime);

        // transform.Rotate(Vector3. * speed * horizontalInput * Time.deltaTime);
        //transform.Rotate(Vector3.forward * verticalInput * Time.deltaTime);
        // tilt the plane up/down based on up/down arrow keys
        //  transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
        //  transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);






        // Rotate the car based on horizontal input
        // transform.Rotate(Vector3.up, 10 * horizontalInput * Time.deltaTime);
    }
}
