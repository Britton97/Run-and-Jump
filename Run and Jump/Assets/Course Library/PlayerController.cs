using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;

    public GameObject runEffect;
    public GameObject explosionEffect;

    public delegate void StopGame();
    public static event StopGame GameOver;

    public AudioClip crashSound;
    public AudioClip jumpSound;
    // Start is called before the first frame update

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            runEffect.SetActive(false);
            playerAudio.PlayOneShot(jumpSound, .25f);
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            runEffect.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            runEffect.SetActive(false);
            explosionEffect.SetActive(true);
            explosionEffect.GetComponent<ParticleSystem>().Play();
            playerAudio.PlayOneShot(crashSound);
            if(GameOver != null)
            {
                GameOver();
            }
        }
    }
}
