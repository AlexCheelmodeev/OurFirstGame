using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitchButton : MonoBehaviour
{
    public void SwitchToNextLevel()
    {
        // Получаем текущий индекс активной сцены.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Загружаем следующий уровень в списке сцен.
        int nextSceneIndex = currentSceneIndex + 1;

        // Проверяем, существует ли следующий уровень, чтобы избежать ошибок.
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No more scenes to load.");
        }
    }
}
