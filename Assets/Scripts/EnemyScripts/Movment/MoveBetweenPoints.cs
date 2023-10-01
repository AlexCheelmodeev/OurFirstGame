using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public Transform[] movePoints; // Массив точек, к которым будет перемещаться объект.
    public float moveSpeed = 5.0f; // Скорость перемещения объекта.
    private int currentPointIndex = 0; // Индекс текущей точки, к которой движется объект.

    void Update()
    {
        // Проверяем, есть ли точки для перемещения и не вышли ли за пределы массива.
        if (movePoints.Length > 0 && currentPointIndex < movePoints.Length)
        {
            // Определяем направление к текущей точке.
            Vector3 direction = movePoints[currentPointIndex].position - transform.position;
            direction.Normalize();

            // Перемещаем объект в направлении текущей точки.
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // Проверяем, достиг ли объект текущей точки.
            if (Vector3.Distance(transform.position, movePoints[currentPointIndex].position) < 0.1f)
            {
                // Если достиг, увеличиваем индекс текущей точки.
                currentPointIndex++;

                // Если достигнут конец массива точек, начинаем движение сначала.
                if (currentPointIndex >= movePoints.Length)
                {
                    currentPointIndex = 0;
                }
            }
        }
    }
}
