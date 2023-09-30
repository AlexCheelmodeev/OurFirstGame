using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRunningAway : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator; // ������ �� �������� ������.
    private string triggerName = "Running"; // �������� �������� ��������.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && playerAnimator != null)
        {
            // ������������� ��������� ������� ��������.
            playerAnimator.SetTrigger(triggerName);
        }
    }
}