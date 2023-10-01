using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPos;
    public Transform player; // ������ �� ������.

    [SerializeField] private float shootingInterval = 1.5f; // �������� ����� ����������.
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
                animator.SetTrigger("Shoot"); // ������������ �������� ��������.
            }
        }
    }

    private bool IsPlayerInShootZone()
    {
        // ���������, ��������� �� ����� ������ ���������� �������.
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
        // ���������, ���� �� ��������� AudioSource � ��������� ��� ����� ��������.
        if (gunshotSound != null && gunshotSound.clip != null)
        {
            // ������������� ���� ��������.
            gunshotSound.PlayOneShot(gunshotSound.clip);
        }

        // ��������� ��� ��� �������� ����.
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

}
