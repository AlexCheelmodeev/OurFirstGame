using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Transform destination; // ����� ���������� ��� ������������.
    public bool isTeleport2; // ���� ��� ����������� ���� ���������.
    public float distance = 0.2f; // ����������� ���������� ��� ��������� ���������.
    public AudioSource teleportSound; // ���� ������������.


    public Animator playerAnimator; // ������ �� �������� ������.

    private void Start()
    {
        // ���������� CompareTag, � �� Tag.
        if (!isTeleport2)
        {
            destination = GameObject.FindGameObjectWithTag("Teleport2").transform;
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("Teleport").transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            // ������������� ���� ������������.
            if (teleportSound != null)
            {
                teleportSound.PlayOneShot(teleportSound.clip);
            }

            // ������ ��������� ������������.
            other.transform.position = new Vector2(destination.position.x, destination.position.y);

            // ������������� ������� �������� � ��������� ������.
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("TeleportPressed");
            }
        }
    }

}