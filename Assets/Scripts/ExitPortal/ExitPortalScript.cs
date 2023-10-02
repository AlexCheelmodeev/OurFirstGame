using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortalScript : MonoBehaviour
{
    public Animator playerAnimator; // Ссылка на аниматор игрока.
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Проверяем, есть ли компонент AudioSource и AudioClip.
            if (audioSource != null && audioSource.clip != null)
            {
                // Воспроизводим аудио при входе в портал.
                audioSource.PlayOneShot(audioSource.clip);
            }

            // Воспроизвести анимацию входа в портал.
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("TeleportPressed");
            }

            // Вызвать метод LoadNextLevel через 1 секунду.
            Invoke("LoadNextLevel", 0.7f);
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