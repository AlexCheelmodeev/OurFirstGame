using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPos;
    public Transform player; // Ссылка на игрока.

    [SerializeField] private float shootingInterval = 1.5f; // Интервал между выстрелами.
    [SerializeField] private float lastShotTime;

    [SerializeField] private Animator animator;
    public AudioSource gunshotSound;

    private void Start()
    {
        lastShotTime = Time.time;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsPlayerInShootZone())
        {
            if (Time.time - lastShotTime >= shootingInterval)
            {
                Shoot();
                lastShotTime = Time.time;
                animator.SetTrigger("Shoot"); // Проигрывание анимации выстрела.
            }
        }
    }

    private bool IsPlayerInShootZone()
    {
        // Проверяем, находится ли игрок внутри коллайдера объекта.
        if (player != null)
        {
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                return collider.bounds.Contains(player.position);
            }
        }
        return false;
    }

    private void Shoot()
    {
        // Проверяем, есть ли компонент AudioSource и аудиофайл для звука выстрела.
        if (gunshotSound != null && gunshotSound.clip != null)
        {
            // Воспроизводим звук выстрела.
            gunshotSound.PlayOneShot(gunshotSound.clip);
        }

        // Остальной код для создания пули.
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

}
