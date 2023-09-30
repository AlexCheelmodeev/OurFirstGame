using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public string playerTag = "Player"; // Укажите тег игрока.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag)) ;
    }
}
