using UnityEngine;
using UnityEngine.UI; // Для работы с текстом на UI-компоненте.

public class DoorController : MonoBehaviour
{
    [SerializeField] private int requiredEnemies = 1; // Количество необходимых врагов.
    private int currentEnemies; // Текущее количество врагов.

    public Text doorText; // Ссылка на текстовый элемент, отображающий количество оставшихся врагов.

    private void Start()
    {
        currentEnemies = requiredEnemies;
        UpdateDoorText();
    }

    public void EnemyDestroyed()
    {
        if (currentEnemies > 0)
        {
            currentEnemies--;
            UpdateDoorText();
        }

        if (currentEnemies == 0)
        {
            OpenDoor();
        }
    }

    private void UpdateDoorText()
    {
        if (doorText != null)
        {
            doorText.text = "Enemies Left: " + currentEnemies.ToString();
        }
    }

    private void OpenDoor()
    {
        // Здесь добавьте код, который должен выполниться при открытии двери.
        // Например, проиграть анимацию или звук, затем уничтожить дверь.
        Destroy(gameObject);
    }
}
