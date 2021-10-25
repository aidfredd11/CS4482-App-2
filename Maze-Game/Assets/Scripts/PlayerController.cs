using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private Animator animator;
    private Rigidbody playerRb;

    public GameObject pauseMenu;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerRb = gameObject.GetComponent<Rigidbody>();

    }

    private void Update()
    {
        Move();
    }

    private void Move()
    { 

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // idle animation when not moving
        if (x == 0 && z == 0)
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsWalking", false);

            playerRb.velocity = Vector3.zero;
        }
        else
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalking", true);

            Vector3 direction = transform.right * x + transform.forward * z;
            direction *= moveSpeed;
            direction.y = playerRb.velocity.y;

            playerRb.velocity = direction;

        }

    }
}
