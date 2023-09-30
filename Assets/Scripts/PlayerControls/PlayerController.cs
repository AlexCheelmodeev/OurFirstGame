using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �������� �������� ������.
    private Animator animator; // ��������� �������� ������.
    private LayerMask wallsLayer;
    private bool isFacingRight = true; // ���� ��� ����������� ����������� ���������.
    private SpriteRenderer spriteRenderer; // ��������� SpriteRenderer.

    private void Start()
    {
        animator = GetComponent<Animator>();
        wallsLayer = LayerMask.GetMask("Walls"); // �������� ���� "Walls" �� ��� �����.
        spriteRenderer = GetComponent<SpriteRenderer>(); // �������� ��������� SpriteRenderer.
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized;

        // ��������� ������� ����� ����� �������.
        Vector2 targetPos = transform.position + movement * moveSpeed * Time.deltaTime;

        if (IsWalkable(targetPos))
        {
            // ���������� ������.
            transform.Translate(movement * moveSpeed * Time.deltaTime);

            // ��������� ���������� isFacingRight � ����������� �� ����������� �������� �� �����������.
            if (horizontalInput > 0)
            {
                isFacingRight = true;
            }
            else if (horizontalInput < 0)
            {
                isFacingRight = false;
            }

            // ������������� �������� "IsRunning" � ��������� �� ������ ���������� isRunning.
            animator.SetBool("IsRunning", (horizontalInput != 0 || verticalInput != 0));
        }

        // ��������� �������� ��������� ��� �������������.
        spriteRenderer.flipX = !isFacingRight;
    }

    private bool IsWalkable(Vector2 targetPos)
    {
        float radius = 0.2f;
        Collider2D hitCollider = Physics2D.OverlapCircle(targetPos, radius, wallsLayer);
        return (hitCollider == null);
    }
}
