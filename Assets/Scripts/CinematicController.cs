using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CinematicController : MonoBehaviour
{
    [SerializeField]private PlayableDirector cinematicDirector; // ������ �� ��������� PlayableDirector � ����� �������������� ���������.

    private bool hasStarted = false;

    private void Update()
    {
        // ���������, �������� �� �������������� ��������.
        if (!hasStarted && cinematicDirector.state == PlayState.Playing)
        {
            hasStarted = true;
        }

        // ���������, ����������� �� �������������� ��������.
        if (hasStarted && cinematicDirector.state != PlayState.Playing)
        {
            // �������� ������� ������ �����.
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // ��������� ��������� ������� (�������� ������� ������ �� 1).
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
