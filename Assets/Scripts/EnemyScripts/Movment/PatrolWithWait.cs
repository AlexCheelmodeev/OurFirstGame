using UnityEngine;

public class PatrolWithWait : MonoBehaviour
{
    public Transform[] patrolPoints; // Массив точек патрулирования.
    public float moveSpeed = 5.0f; // Скорость движения объекта.
    public float waitTime = 2.0f; // Время ожидания в каждой точке.

    private int currentPatrolIndex = 0; // Индекс текущей точки патрулирования.
    private float waitStartTime; // Время начала ожидания.

    private void Update()
    {
        // Проверяем, что есть хотя бы одна точка патрулирования.
        if (patrolPoints.Length > 0)
        {
            // Получаем текущую точку патрулирования.
            Transform currentPatrolPoint = patrolPoints[currentPatrolIndex];

            // Вычисляем вектор направления к текущей точке.
            Vector3 directionToPatrolPoint = currentPatrolPoint.position - transform.position;

            // Нормализуем вектор направления, чтобы получить только направление без длины.
            directionToPatrolPoint.Normalize();

            // Если объект приблизился к текущей точке, ждем заданное время перед переходом к следующей точке.
            if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 0.1f)
            {
                if (Time.time - waitStartTime >= waitTime)
                {
                    // Переходим к следующей точке патрулирования.
                    currentPatrolIndex++;

                    // Если достигли последней точки, начинаем патрулирование с начала.
                    if (currentPatrolIndex >= patrolPoints.Length)
                    {
                        currentPatrolIndex = 0;
                    }

                    // Сбрасываем время ожидания.
                    waitStartTime = Time.time;
                }
            }
            else
            {
                // Перемещаем объект в направлении текущей точки.
                transform.Translate(directionToPatrolPoint * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            Debug.LogError("Отсутствуют точки патрулирования.");
        }
    }
}
