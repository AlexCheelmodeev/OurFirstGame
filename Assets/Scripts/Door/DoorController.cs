using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator; // Ссылка на компонент анимации двери.
    [SerializeField] private Canvas doorCanvas; // Ссылка на Canvas с текстом.

    private bool playerNearDoor = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearDoor = true;
            doorCanvas.enabled = true; // Включаем Canvas с текстом при подходе игрока к двери.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearDoor = false;
            doorCanvas.enabled = false; // Выключаем Canvas с текстом, когда игрок уходит от двери.
        }
    }

    private void Update()
    {
        if (playerNearDoor && Input.GetKeyDown(KeyCode.E))
        {
            // Проигрываем анимацию открытия двери.
            doorAnimator.SetTrigger("Open");
        }
    }
}
