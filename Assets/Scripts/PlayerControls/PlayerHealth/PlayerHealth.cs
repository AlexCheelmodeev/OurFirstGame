using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // Максимальное количество здоровья игрока.
    private int currentHealth; // Текущее количество здоровья игрока.
    public float invulnerabilityDuration = 1.0f; // Длительность неуязвимости после получения урона.
    private bool isInvulnerable = false; // Флаг для неуязвимости игрока.
    private float invulnerabilityTimer = 0.0f; // Таймер неуязвимости.
    public Image[] heartImages; // Массив изображений сердечек.
    [SerializeField] private Animator animator; // Ссылка на компонент аниматора.
    public Sprite fullHeartSprite; // Спрайт полного сердечка.
    public Sprite emptyHeartSprite; // Спрайт пустого сердечка;

    private void Start()
    {
        currentHealth = maxHealth; // Устанавливаем начальное здоровье.
        animator = GetComponent<Animator>(); // Получаем компонент аниматора.
        UpdateHealthUI(); // Обновляем отображение здоровья.
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

            animator.SetTrigger("IsHurt"); // Включаем триггер "IsHurt" в аниматоре.

            isInvulnerable = true;
            invulnerabilityTimer = invulnerabilityDuration;

            if (currentHealth == 0)
            {
                Die(); // Добавьте метод Die() для обработки смерти игрока.
            }
        }
    }

    private void UpdateHealthUI()
    {
        // Обновляем отображение здоровья на экране.
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentHealth)
            {
                // Отображаем полное сердечко.
                heartImages[i].sprite = fullHeartSprite;
            }
            else
            {
                // Отображаем пустое сердечко.
                heartImages[i].sprite = emptyHeartSprite;
            }
        }
    }

        private void Die()
    {
        // Добавьте код для обработки смерти игрока здесь.
        // Например, проигрывание анимации смерти или перезапуск уровня.
    }
}
