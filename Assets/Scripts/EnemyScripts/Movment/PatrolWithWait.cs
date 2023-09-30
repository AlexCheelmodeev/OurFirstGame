using UnityEngine;

public class PatrolWithWait : MonoBehaviour
{
    public Transform[] patrolPoints; // ������ ����� ��������������.
    public float moveSpeed = 5.0f; // �������� �������� �������.
    public float waitTime = 2.0f; // ����� �������� � ������ �����.

    private int currentPatrolIndex = 0; // ������ ������� ����� ��������������.
    private float waitStartTime; // ����� ������ ��������.

    private void Update()
    {
        // ���������, ��� ���� ���� �� ���� ����� ��������������.
        if (patrolPoints.Length > 0)
        {
            // �������� ������� ����� ��������������.
            Transform currentPatrolPoint = patrolPoints[currentPatrolIndex];

            // ��������� ������ ����������� � ������� �����.
            Vector3 directionToPatrolPoint = currentPatrolPoint.position - transform.position;

            // ����������� ������ �����������, ����� �������� ������ ����������� ��� �����.
            directionToPatrolPoint.Normalize();

            // ���� ������ ����������� � ������� �����, ���� �������� ����� ����� ��������� � ��������� �����.
            if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 0.1f)
            {
                if (Time.time - waitStartTime >= waitTime)
                {
                    // ��������� � ��������� ����� ��������������.
                    currentPatrolIndex++;

                    // ���� �������� ��������� �����, �������� �������������� � ������.
                    if (currentPatrolIndex >= patrolPoints.Length)
                    {
                        currentPatrolIndex = 0;
                    }

                    // ���������� ����� ��������.
                    waitStartTime = Time.time;
                }
            }
            else
            {
                // ���������� ������ � ����������� ������� �����.
                transform.Translate(directionToPatrolPoint * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            Debug.LogError("����������� ����� ��������������.");
        }
    }
}
