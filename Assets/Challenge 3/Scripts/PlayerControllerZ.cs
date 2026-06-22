using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerZ : MonoBehaviour
{
    public bool gameOver;

    public float floatForce = 5.0f;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound; 

    private float maxBound = 13.0f; 

    // Start is called before the first frame update
    void Start()
    {
        
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.Space) && !gameOver && transform.position.y < maxBound)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }

        
        if (transform.position.y > maxBound)
        {
            transform.position = new Vector3(transform.position.x, maxBound, transform.position.z);
            playerRb.linearVelocity = new Vector3(playerRb.linearVelocity.x, 0, playerRb.linearVelocity.z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }
        
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.transform.position = transform.position; 
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        }
        
        else if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            playerRb.AddForce(Vector3.up * 7.0f, ForceMode.Impulse);
            if (bounceSound != null) playerAudio.PlayOneShot(bounceSound, 1.0f);
        }
    }
}