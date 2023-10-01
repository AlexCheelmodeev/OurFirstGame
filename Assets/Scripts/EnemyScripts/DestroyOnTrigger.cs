using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public GameObject objectToDestroy; // Ссылка на объект для уничтожения.
    public AudioSource audioSource; // Ссылка на компонент AudioSource.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверяем, является ли объект игроком.
        {
            // Уничтожаем объект, если он задан.
            if (objectToDestroy != null)
            {
                audioSource.Play();
                Destroy(objectToDestroy);

            }
        }
    }
}
