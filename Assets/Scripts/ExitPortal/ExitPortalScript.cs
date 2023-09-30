using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortalScript : MonoBehaviour
{
    public Animator playerAnimator; // Ссылка на аниматор игрока.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Воспроизвести анимацию входа в портал.
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("TeleportPressed");
            }

            // Вызвать метод LoadNextLevel через 1 секунду.
            Invoke("LoadNextLevel", 1f);
        }
    }

    private void LoadNextLevel()
    {
        // Получить текущий индекс сцены.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Загрузить следующий уровень (увеличив текущий индекс на 1).
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}