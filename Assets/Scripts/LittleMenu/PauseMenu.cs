using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; // ������ �� ������ ���� �����.
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
        Time.timeScale = 1f; // ������������ ����� ����.
        pauseMenu.SetActive(false); // ��������� ���� �����.
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // ������������� ����� ����.
        pauseMenu.SetActive(true); // �������� ���� �����.
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; // ������������ ����� ���� ����� ������� � ������� ����.
        SceneManager.LoadScene("MainMenu"); // �������� "MainMenu" �� ��� ����� ������ �������� ����.
    }
}
