using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public string playerTag = "Player"; // ������� ��� ������.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag)) ;
    }
}
