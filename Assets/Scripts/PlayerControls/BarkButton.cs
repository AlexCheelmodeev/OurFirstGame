using UnityEngine;

public class BarkButton : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator; // ������ �� �������� ������.
    [SerializeField] private AudioClip buttonSound; // ����, ������� ����� ������������� ��� ������� ������ E.

    private void Update()
    {
        // ���������, ������ �� ������� "E".
        if (Input.GetKeyDown(KeyCode.E))
        {
            // ��������� ������� ��������� ������.
            if (playerAnimator != null)
            {
                // ����������� ������� "ISTriggered" � ��������� ������.
                playerAnimator.SetTrigger("IsTriggered");
            }

            // ��������� ������� �����.
            if (buttonSound != null)
            {
                // ����������� ���������, ����������� � ���������.
                AudioSource audioSource = GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.clip = buttonSound;
                    audioSource.Play();
                }
            }
        }
    }
}
