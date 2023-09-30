using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public GameObject objectToDestroy; // Ссылка на объект для уничтожения.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверяем, является ли объект игроком.
        {
            // Уничтожаем объект, если он задан.
            if (objectToDestroy != null)
            {
                Destroy(objectToDestroy);
            }
        }
    }
}