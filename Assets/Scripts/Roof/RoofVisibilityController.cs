using UnityEngine;

public class RoofVisibilityController : MonoBehaviour
{
    public GameObject roof; // Ссылка на объект крыши, которую нужно скрывать.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            roof.SetActive(false); // Выключаем крышу при входе в триггер.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            roof.SetActive(true); // Включаем крышу при выходе из триггера.
        }
    }
}
