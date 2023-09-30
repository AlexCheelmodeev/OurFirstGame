using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public GameObject objectToDestroy; // ������ �� ������ ��� �����������.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ���������, �������� �� ������ �������.
        {
            // ���������� ������, ���� �� �����.
            if (objectToDestroy != null)
            {
                Destroy(objectToDestroy);
            }
        }
    }
}