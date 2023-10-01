using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    public int damage = 1; // Урон, наносимый снарядом.
    [SerializeField] private float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = (player.transform.position - transform.position).normalized;
        // Используйте transform.right для определения начального направления снаряда.
        transform.right = direction;
    }

    void Update()
    {
        // Используйте transform.right для движения в направлении вращения снаряда.
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            // Уничтожаем снаряд при столкновении с объектами на слое "Walls".
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            // Получаем компонент здоровья игрока (если он есть).
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Наносим урон игроку.
                playerHealth.TakeDamage(damage);
            }

            // Уничтожаем снаряд после столкновения с игроком.
            Destroy(gameObject);
        }

    }
}
