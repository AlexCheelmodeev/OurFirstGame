using UnityEngine;

public class EnemyDmgDealer : MonoBehaviour
{
    public int damageAmount = 1; // Количество урона, который наносит враг.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Получаем компонент здоровья игрока.
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Наносим урон игроку.
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
