using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; // Ссылка на панель меню паузы.
    private bool isPaused = false;

    private void Start()
    {
        ResumeGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Возобновляем время игры.
        pauseMenu.SetActive(false); // Выключаем меню паузы.
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Останавливаем время игры.
        pauseMenu.SetActive(true); // Включаем меню паузы.
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; // Возобновляем время игры перед выходом в главное меню.
        SceneManager.LoadScene("MainMenu"); // Замените "MainMenu" на имя сцены вашего главного меню.
    }
}
