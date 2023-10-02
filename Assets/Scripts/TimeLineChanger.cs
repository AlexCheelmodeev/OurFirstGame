using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLineChanger : MonoBehaviour
{
    [SerializeField]private float delayBeforeSwitching = 4.0f;

    private float timer = 0f;
    private bool shouldSwitchLevel = false;

    private void Update()
    {
        // ����������� ������ ������ ����.
        timer += Time.deltaTime;

        // ���� ������ ���������� ������� � ��� �� ����������� �������, �� �����������.
        if (timer >= delayBeforeSwitching && !shouldSwitchLevel)
        {
            shouldSwitchLevel = true;
            SwitchLevel();
        }
    }

    private void SwitchLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;

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
