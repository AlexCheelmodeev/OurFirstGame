using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    public int damage = 1; // ����, ��������� ��������.
    [SerializeField] private float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = (player.transform.position - transform.position).normalized;
        // ����������� transform.right ��� ����������� ���������� ����������� �������.
        transform.right = direction;
    }

    void Update()
    {
        // ����������� transform.right ��� �������� � ����������� �������� �������.
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            // ���������� ������ ��� ������������ � ��������� �� ���� "Walls".
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            // �������� ��������� �������� ������ (���� �� ����).
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // ������� ���� ������.
                playerHealth.TakeDamage(damage);
            }

            // ���������� ������ ����� ������������ � �������.
            Destroy(gameObject);
        }

    }
}
