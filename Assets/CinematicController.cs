using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CinematicController : MonoBehaviour
{
    [SerializeField]private PlayableDirector cinematicDirector; // Ссылка на компонент PlayableDirector с вашей синематической анимацией.

    private bool hasStarted = false;

    private void Update()
    {
        // Проверяем, началась ли синематическая анимация.
        if (!hasStarted && cinematicDirector.state == PlayState.Playing)
        {
            hasStarted = true;
        }

        // Проверяем, завершилась ли синематическая анимация.
        if (hasStarted && cinematicDirector.state != PlayState.Playing)
        {
            // Получаем текущий индекс сцены.
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Загружаем следующий уровень (увеличив текущий индекс на 1).
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
