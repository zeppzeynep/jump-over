using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem dirt;
    public ParticleSystem puff;
    private Rigidbody playerRb;
    private Animator playerAnim;
    public bool gameOver;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;


    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirt.Stop();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
            dirt.Play();

        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            puff.Play();
            dirt.Stop();
        }
    }
}