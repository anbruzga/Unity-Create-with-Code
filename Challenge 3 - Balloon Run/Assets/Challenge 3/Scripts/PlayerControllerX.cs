using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = false;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    public float maxAllowedHeight = 12f;
    public float minAllowedHeight = 15f;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && !TopCollision())
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
        else if (Input.GetKey(KeyCode.Space) && !gameOver && TopCollision())
        { 
          //  playerRb.AddForce(Vector3.down * floatForce);
        }
        


    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            playerRb.AddForce(Vector3.up * floatForce * 15f);
            Destroy(other.gameObject);
        }

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }
        else if (other.gameObject.CompareTag("Ground")) {
            if (!gameOver)
            {
                playerRb.AddForce(Vector3.up * floatForce * 5.2f);
            }

            else if (gameOver)
            {
                playerRb.AddForce(Vector3.up * floatForce * 0.01f);
            }
        }
        else if (other.gameObject.CompareTag("SkyPlane"))
        {
            if (!gameOver)
            {
                playerRb.AddForce(Vector3.down * floatForce * 2.2f);
            }

            else if (gameOver)
            {
                playerRb.AddForce(Vector3.down * floatForce * 5f);
            }
        }
    }

    private bool TopCollision()
    {
        if (transform.position.y > maxAllowedHeight)
        {
            return true;
        }
        else return false;
    }

    
}
