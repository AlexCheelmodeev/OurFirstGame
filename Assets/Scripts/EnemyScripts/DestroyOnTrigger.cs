using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public GameObject objectToDestroy; // ������ �� ������ ��� �����������.
    public AudioSource audioSource; // ������ �� ��������� AudioSource.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ���������, �������� �� ������ �������.
        {
            // ���������� ������, ���� �� �����.
            if (objectToDestroy != null)
            {
                audioSource.Play();
                Destroy(objectToDestroy);

            }
        }
    }
}
