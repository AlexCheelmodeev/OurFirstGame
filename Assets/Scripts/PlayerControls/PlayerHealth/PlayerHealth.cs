using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // ������������ ���������� �������� ������.
    private int currentHealth; // ������� ���������� �������� ������.
    public float invulnerabilityDuration = 1.0f; // ������������ ������������ ����� ��������� �����.
    private bool isInvulnerable = false; // ���� ��� ������������ ������.
    private float invulnerabilityTimer = 0.0f; // ������ ������������.
    public Image[] heartImages; // ������ ����������� ��������.
    [SerializeField] private Animator animator; // ������ �� ��������� ���������.
    public Sprite fullHeartSprite; // ������ ������� ��������.
    public Sprite emptyHeartSprite; // ������ ������� ��������;

    private void Start()
    {
        currentHealth = maxHealth; // ������������� ��������� ��������.
        animator = GetComponent<Animator>(); // �������� ��������� ���������.
        UpdateHealthUI(); // ��������� ����������� ��������.
    }

    private void Update()
    {
        if (isInvulnerable)
        {
            invulnerabilityTimer -= Time.deltaTime;

            if (invulnerabilityTimer <= 0)
            {
                isInvulnerable = false;
            }
        }
    }

    public void TakeDamage(int amount)
    {
        if (!isInvulnerable)
        {
            currentHealth -= amount;

            if (currentHealth < 0)
            {
                currentHealth = 0;
            }

            UpdateHealthUI();

            animator.SetTrigger("IsHurt"); // �������� ������� "IsHurt" � ���������.

            isInvulnerable = true;
            invulnerabilityTimer = invulnerabilityDuration;

            if (currentHealth == 0)
            {
                Die(); // �������� ����� Die() ��� ��������� ������ ������.
            }
        }
    }

    private void UpdateHealthUI()
    {
        // ��������� ����������� �������� �� ������.
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentHealth)
            {
                // ���������� ������ ��������.
                heartImages[i].sprite = fullHeartSprite;
            }
            else
            {
                // ���������� ������ ��������.
                heartImages[i].sprite = emptyHeartSprite;
            }
        }
    }

        private void Die()
    {
        // �������� ��� ��� ��������� ������ ������ �����.
        // ��������, ������������ �������� ������ ��� ���������� ������.
    }
}
