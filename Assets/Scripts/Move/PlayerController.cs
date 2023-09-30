using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �������� �������� ������.
    private Animator animator; // ��������� �������� ������.
    bool isRunning = false;
    private LayerMask wallsLayer;
    private bool isFacingRight = true; // ���� ��� ����������� ����������� ���������.

    private void Start()
    {
        animator = GetComponent<Animator>();
        wallsLayer = LayerMask.GetMask("Walls"); // �������� ���� "Walls" �� ��� �����.
    }

    private void Update()
    {
        // �������� ���� �� ������.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ��������� ������ ����������� �������� ������.
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized;

        // ��������� ������� ����� ����� �������.
        Vector2 targetPos = transform.position + movement * moveSpeed * Time.deltaTime;

        if (IsWalkable(targetPos))
        {
            // ���������� ������.
            transform.Translate(movement * moveSpeed * Time.deltaTime);

            // ��������� ���������� isRunning � ����������� �� �������� ������.
            isRunning = (horizontalInput != 0 || verticalInput != 0);

            // ������������� �������� "IsRunning" � ��������� �� ������ ���������� isRunning.
            animator.SetBool("IsRunning", isRunning);

            // ���������� ����������� ��������� � ������������� ��� ��� �������������.
            if (horizontalInput > 0 && !isFacingRight)
            {
                FlipCharacter();
            }
            else if (horizontalInput < 0 && isFacingRight)
            {
                FlipCharacter();
            }

            // ��������� ������� ������� � � ����������� ������� � ���������.
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("IsTriggered");
            }
        }
    }

    private bool IsWalkable(Vector2 targetPos)
    {
        // ������ ��� �������� ������������ � ��������� �� ���� "Walls".
        float radius = 0.2f;

        // ��������� ������� ������������ � ��������� �� ���� "Walls".
        Collider2D hitCollider = Physics2D.OverlapCircle(targetPos, radius, wallsLayer);

        // ���� ��� �����, ���������� true, ����� ���������� false.
        return (hitCollider == null);
    }

    private void FlipCharacter()
    {
        // ������������� ���������, ���������� ������� �� ��� X.
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        // ��������� ���� �����������.
        isFacingRight = !isFacingRight;

        Debug.Log("Character flipped!"); // ��������� ���������� �����.
    }

}
