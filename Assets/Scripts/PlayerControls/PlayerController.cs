using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Скорость движения игрока.
    private Animator animator; // Компонент анимации игрока.
    private LayerMask wallsLayer;
    private bool isFacingRight = true; // Флаг для определения направления персонажа.
    private SpriteRenderer spriteRenderer; // Компонент SpriteRenderer.

    private void Start()
    {
        animator = GetComponent<Animator>();
        wallsLayer = LayerMask.GetMask("Walls"); // Получаем слой "Walls" по его имени.
        spriteRenderer = GetComponent<SpriteRenderer>(); // Получаем компонент SpriteRenderer.
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized;

        // Проверяем наличие стены перед игроком.
        Vector2 targetPos = transform.position + movement * moveSpeed * Time.deltaTime;

        if (IsWalkable(targetPos))
        {
            // Перемещаем игрока.
            transform.Translate(movement * moveSpeed * Time.deltaTime);

            // Обновляем переменную isFacingRight в зависимости от направления движения по горизонтали.
            if (horizontalInput > 0)
            {
                isFacingRight = true;
            }
            else if (horizontalInput < 0)
            {
                isFacingRight = false;
            }

            // Устанавливаем параметр "IsRunning" в аниматоре на основе переменной isRunning.
            animator.SetBool("IsRunning", (horizontalInput != 0 || verticalInput != 0));
        }

        // Зеркально отражаем персонажа при необходимости.
        spriteRenderer.flipX = !isFacingRight;
    }

    private bool IsWalkable(Vector2 targetPos)
    {
        float radius = 0.2f;
        Collider2D hitCollider = Physics2D.OverlapCircle(targetPos, radius, wallsLayer);
        return (hitCollider == null);
    }
}
