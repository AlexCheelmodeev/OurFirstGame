using UnityEngine;

public class RoofVisibilityController : MonoBehaviour
{
    public GameObject roof; // ������ �� ������ �����, ������� ����� ��������.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            roof.SetActive(false); // ��������� ����� ��� ����� � �������.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            roof.SetActive(true); // �������� ����� ��� ������ �� ��������.
        }
    }
}
