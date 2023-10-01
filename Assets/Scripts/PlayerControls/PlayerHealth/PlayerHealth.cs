using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 3; // ������������ ���������� �������� ������.
    private int currentHealth; // ������� ���������� �������� ������.
    public float invulnerabilityDuration = 1.0f; // ������������ ������������ ����� ��������� �����.
    private bool isInvulnerable = false; // ���� ��� ������������ ������.
    private float invulnerabilityTimer = 0.0f; // ������ ������������.
    public Image[] heartImages; // ������ ����������� ��������.
    [SerializeField] private Animator animator; // ������ �� ��������� ���������.
    public Sprite fullHeartSprite; // ������ ������� ��������.
    public Sprite emptyHeartSprite; // ������ ������� ��������.
    public AudioSource damageSound; // ���� ��������� �����.


    public AudioSource deathSound; // ���� ������.
    public GameObject gameOverUI; // ������ ��� ����������� ������ Game Over.
    public GameObject pauseButton; // ������ �����.

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
            // ������������� ���� ��������� �����.
            if (damageSound != null)
            {
                damageSound.PlayOneShot(damageSound.clip);
            }

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
                Die(); // ��������� ������ ������.
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
        // ������������� ���� ������.
        if (deathSound != null)
        {
            deathSound.Play();
        }

        // ��������� ������ �����.
        if (pauseButton != null)
        {
            pauseButton.SetActive(false);
        }

        // ���������� ����� Game Over.
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        // ���������� ���� �� �����.
        Time.timeScale = 0f;

        // ������ ��������, ������� ����� ��������� ��� ������ ������.
    }
}
