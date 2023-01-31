using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    /*public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    public float jumpForce;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            GameOver();
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }
    }

    void GameOver()
    {
        gameOver = true;
    }
    private void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    */

    private Rigidbody _rigidbody;
    public float jumpForce = 10f;

    public bool gameOver;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver )
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }
       
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            GameOver();
            Debug.Log("Game Over!");
            Destroy(otherCollider.gameObject);
            Destroy(gameObject,1); //time to destroy

        }
        if (otherCollider.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            Destroy(otherCollider.gameObject);
            
        }
        else if (otherCollider.gameObject.CompareTag("Ground"))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOver = true;
    }
}
