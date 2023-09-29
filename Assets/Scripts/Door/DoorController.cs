using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator; // ������ �� ��������� �������� �����.
    [SerializeField] private Canvas doorCanvas; // ������ �� Canvas � �������.

    private bool playerNearDoor = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearDoor = true;
            doorCanvas.enabled = true; // �������� Canvas � ������� ��� ������� ������ � �����.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearDoor = false;
            doorCanvas.enabled = false; // ��������� Canvas � �������, ����� ����� ������ �� �����.
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
