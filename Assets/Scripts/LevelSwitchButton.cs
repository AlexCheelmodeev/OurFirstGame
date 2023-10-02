using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitchButton : MonoBehaviour
{
    public void SwitchToNextLevel()
    {
        // �������� ������� ������ �������� �����.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ��������� ��������� ������� � ������ ����.
        int nextSceneIndex = currentSceneIndex + 1;

        // ���������, ���������� �� ��������� �������, ����� �������� ������.
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
