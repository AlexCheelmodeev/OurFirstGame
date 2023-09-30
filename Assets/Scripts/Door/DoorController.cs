using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator; // Ссылка на компонент анимации двери.
    [SerializeField] private GameObject doorCanvas; // Ссылка на GameObject с текстом.

    private bool playerNearDoor = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearDoor = true;
            doorCanvas.SetActive(true); // Включаем GameObject с текстом при подходе игрока к двери.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearDoor = false;
            doorCanvas.SetActive(false); // Выключаем GameObject с текстом, когда игрок уходит от двери.
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
