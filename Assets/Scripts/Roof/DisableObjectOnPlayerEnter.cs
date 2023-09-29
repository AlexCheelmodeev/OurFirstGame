using UnityEngine;

public class DisableObjectOnPlayerEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false); // Выключаем текущий объект при входе игрока.
        }
    }
}
