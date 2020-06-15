using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    public GameObject powerupIndicator2;
    private int hasPowerup = 0;
    private float powerupStrength = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        powerupIndicator2.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = hasPowerup + 1;

            if (hasPowerup > 0)
            {
                powerupIndicator.gameObject.SetActive(true);
            }
            if (hasPowerup > 1)
            {
                powerupIndicator2.gameObject.SetActive(true);
            }
        }

        StartCoroutine(PowerupCountdownRoutine());

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup > 0)
        {
            Debug.Log("Player Collided with " + collision.gameObject
                + " with powerup set to " + hasPowerup);

            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector2 awayFromPlayer = (collision.gameObject.transform.position
                - transform.position);
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
           

           

        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        if (hasPowerup > 0) {
            hasPowerup = hasPowerup - 1;
        }

        if (hasPowerup < 1)
        {
            powerupIndicator.gameObject.SetActive(false);
            powerupIndicator2.gameObject.SetActive(false);
        }
        else if (hasPowerup < 2)
        {
            powerupIndicator2.gameObject.SetActive(false);
        }
    }
}
