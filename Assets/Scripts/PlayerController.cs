using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    private Rigidbody playerRb;


  
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
