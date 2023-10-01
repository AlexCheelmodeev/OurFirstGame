using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    [SerializeField] private int requiredEnemies = 1;
    private int currentEnemies;

    public Text doorText;
    private Animator doorAnimator;
    private bool isPlayerInsideDoorCollider = false;
    public AudioSource doorAudioSource;

    private void Start()
    {
        currentEnemies = requiredEnemies;
        UpdateDoorText();

        // Получаем компонент Animator у двери.
        doorAnimator = GetComponent<Animator>();
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
            isPlayerInsideDoorCollider = true;
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
        // Запускаем анимацию открытия двери, устанавливая триггер "IsOpening".
        doorAnimator.SetTrigger("IsOpening");
        doorAudioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isPlayerInsideDoorCollider && other.CompareTag("Player"))
        {
            // Проверяем, что условие выполнено и объект, вошедший в коллайдер, является игроком.
            OpenDoor();
        }
    }



}
