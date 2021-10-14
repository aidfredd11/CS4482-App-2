using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    // public Rigidbody playerRb;

    private Animator animator;
    private CapsuleCollider capsuleCollider;
    private Rigidbody playerRb;

    private bool isMoving;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // idle animation when not moving
        if ((x == 0 && z == 0) || (x != 0 && z == 0))
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
