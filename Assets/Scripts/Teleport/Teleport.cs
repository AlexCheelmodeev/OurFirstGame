using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Transform destination; // Пункт назначения для телепортации.
    public bool isTeleport2; // Флаг для определения типа телепорта.
    public float distance = 0.2f; // Минимальное расстояние для активации телепорта.

    public Animator playerAnimator; // Ссылка на аниматор игрока.

    private void Start()
    {
        // Используем CompareTag, а не Tag.
        if (!isTeleport2)
        {
            destination = GameObject.FindGameObjectWithTag("Teleport2").transform;
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("Teleport").transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            // Используем destination.position.x, а не distanse.position.x.
            other.transform.position = new Vector2(destination.position.x, destination.position.y);

            // Устанавливаем триггер анимации в аниматоре игрока.
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("TeleportPressed");
            }
        }
    }
}