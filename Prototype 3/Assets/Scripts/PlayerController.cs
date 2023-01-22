using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 700.0f;
    public float gravityMpodifier = 1.5f;
    public bool gameOver = false;
    public ParticleSystem explosionPartical;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private Rigidbody playerRb;
    private bool isOnGround = true;
    private Animator playerAnim;
    private AudioSource playerAudio;
    private bool accessDoubleJump = false;
    private int countJump = 0;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>(); 
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityMpodifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isOnGround || accessDoubleJump) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround= false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            countJump++;
            if (countJump == 1)
                accessDoubleJump = true;
            else
                accessDoubleJump = false;
        }

        if (gameOver)
            dirtParticle.Stop();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
            countJump = 0;
            accessDoubleJump = false;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionPartical.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
