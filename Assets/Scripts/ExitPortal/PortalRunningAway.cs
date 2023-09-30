using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRunningAway : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator; // Ссылка на аниматор игрока.
    private string triggerName = "Running"; // Название триггера анимации.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && playerAnimator != null)
        {
            // Воспроизводим указанный триггер анимации.
            playerAnimator.SetTrigger(triggerName);
        }
    }
}