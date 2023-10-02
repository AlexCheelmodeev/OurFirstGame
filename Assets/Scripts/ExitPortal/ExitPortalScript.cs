using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortalScript : MonoBehaviour
{
    public Animator playerAnimator; // ������ �� �������� ������.
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ���������, ���� �� ��������� AudioSource � AudioClip.
            if (audioSource != null && audioSource.clip != null)
            {
                // ������������� ����� ��� ����� � ������.
                audioSource.PlayOneShot(audioSource.clip);
            }

            // ������������� �������� ����� � ������.
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("TeleportPressed");
            }

            // ������� ����� LoadNextLevel ����� 1 �������.
            Invoke("LoadNextLevel", 0.7f);
        }
    }


    private void LoadNextLevel()
    {
        // �������� ������� ������ �����.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ��������� ��������� ������� (�������� ������� ������ �� 1).
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}