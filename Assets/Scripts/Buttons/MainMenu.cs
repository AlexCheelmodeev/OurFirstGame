using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject creatorsPanel; // Ссылка на панель с информацией о создателях.
    [SerializeField] private GameObject controlsPanel; // Ссылка на панель с управлением.

    private bool creatorsPanelActive = false; // Флаг, показывающий, активна ли панель создателей.
    private bool controlsPanelActive = false; // Флаг, показывающий, активна ли панель управления.

    private void Start()
    {
        // Изначально скрываем панели с информацией о создателях и управлением.
        creatorsPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void StartGame()
    {
        // Загружаем первый уровень (или другой уровень, который вы хотите использовать для начала игры).
        SceneManager.LoadScene("Level1"); // Замените "Level1" на имя вашего уровня.
    }

    public void ShowCreators()
    {
        // Переключаем состояние панели с информацией о создателях.
        creatorsPanelActive = !creatorsPanelActive;
        creatorsPanel.SetActive(creatorsPanelActive);
    }

    public void ShowControls()
    {
        // Переключаем состояние панели с управлением.
        controlsPanelActive = !controlsPanelActive;
        controlsPanel.SetActive(controlsPanelActive);
    }

    public void QuitGame()
    {
        // Выход из игры (работает в сборке приложения).
        Application.Quit();
    }
}
