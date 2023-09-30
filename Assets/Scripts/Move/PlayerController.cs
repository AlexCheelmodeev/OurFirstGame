using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Скорость движения игрока.
    private Animator animator; // Компонент анимации игрока.
    bool isRunning = false;
    private LayerMask wallsLayer;
    private bool isFacingRight = true; // Флаг для определения направления персонажа.

    private void Start()
    {
        animator = GetComponent<Animator>();
        wallsLayer = LayerMask.GetMask("Walls"); // Получаем слой "Walls" по его имени.
    }

    private void Update()
    {
        // Получаем ввод от игрока.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Вычисляем вектор направления движения игрока.
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized;

        // Проверяем наличие стены перед игроком.
        Vector2 targetPos = transform.position + movement * moveSpeed * Time.deltaTime;

        if (IsWalkable(targetPos))
        {
            // Перемещаем игрока.
            transform.Translate(movement * moveSpeed * Time.deltaTime);

            // Обновляем переменную isRunning в зависимости от действий игрока.
            isRunning = (horizontalInput != 0 || verticalInput != 0);

            // Устанавливаем параметр "IsRunning" в аниматоре на основе переменной isRunning.
            animator.SetBool("IsRunning", isRunning);

            // Определяем направление персонажа и разворачиваем его при необходимости.
            if (horizontalInput > 0 && !isFacingRight)
            {
                FlipCharacter();
            }
            else if (horizontalInput < 0 && isFacingRight)
            {
                FlipCharacter();
            }

            // Проверяем нажатие клавиши Е и проигрываем триггер в аниматоре.
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("IsTriggered");
            }
        }
    }

    private bool IsWalkable(Vector2 targetPos)
    {
        // Радиус для проверки столкновения с объектами на слое "Walls".
        float radius = 0.2f;

        // Выполняем лучевое столкновение с объектами на слое "Walls".
        Collider2D hitCollider = Physics2D.OverlapCircle(targetPos, radius, wallsLayer);

        // Если нет стены, возвращаем true, иначе возвращаем false.
        return (hitCollider == null);
    }

    private void FlipCharacter()
    {
        // Разворачиваем персонажа, инвертируя масштаб по оси X.
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        // Обновляем флаг направления.
        isFacingRight = !isFacingRight;

        Debug.Log("Character flipped!"); // Добавляем отладочный вывод.
    }

}
