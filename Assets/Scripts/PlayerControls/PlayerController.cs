using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movement = new Vector2(horizontalInput, verticalInput).normalized;

        if (movement != Vector2.zero)
        {
            animator.SetBool("IsRunning", true);

            if (horizontalInput < 0 && verticalInput < 0)
            {
                animator.SetBool("IsRunningReverse", true);
            }
            else
            {
                animator.SetBool("IsRunningReverse", false);
            }
        }
        else
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsRunningReverse", false);
        }

        // ќбработка движени€ и управление персонажем.
        // ...
    }

    private void FixedUpdate()
    {
        // ѕрименение движени€ в физическом обновлении.
        rb.velocity = movement * moveSpeed;
    }
}
