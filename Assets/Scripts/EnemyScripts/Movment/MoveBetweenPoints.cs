using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public Transform[] movePoints; // ������ �����, � ������� ����� ������������ ������.
    public float moveSpeed = 5.0f; // �������� ����������� �������.
    private int currentPointIndex = 0; // ������ ������� �����, � ������� �������� ������.

    void Update()
    {
        // ���������, ���� �� ����� ��� ����������� � �� ����� �� �� ������� �������.
        if (movePoints.Length > 0 && currentPointIndex < movePoints.Length)
        {
            // ���������� ����������� � ������� �����.
            Vector3 direction = movePoints[currentPointIndex].position - transform.position;
            direction.Normalize();

            // ���������� ������ � ����������� ������� �����.
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // ���������, ������ �� ������ ������� �����.
            if (Vector3.Distance(transform.position, movePoints[currentPointIndex].position) < 0.1f)
            {
                // ���� ������, ����������� ������ ������� �����.
                currentPointIndex++;

                // ���� ��������� ����� ������� �����, �������� �������� �������.
                if (currentPointIndex >= movePoints.Length)
                {
                    currentPointIndex = 0;
                }
            }
        }
    }
}
