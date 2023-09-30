using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator; // ������ �� ��������� �������� �����.
    [SerializeField] private GameObject doorCanvas; // ������ �� GameObject � �������.

    private bool playerNearDoor = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearDoor = true;
            doorCanvas.SetActive(true); // �������� GameObject � ������� ��� ������� ������ � �����.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearDoor = false;
            doorCanvas.SetActive(false); // ��������� GameObject � �������, ����� ����� ������ �� �����.
        }
    }

    private void Update()
    {
        if (playerNearDoor && Input.GetKeyDown(KeyCode.E))
        {
            // ����������� �������� �������� �����.
            doorAnimator.SetTrigger("Open");
        }
    }
}
