using UnityEngine;
using UnityEngine.UI; // ��� ������ � ������� �� UI-����������.

public class DoorController : MonoBehaviour
{
    [SerializeField] private int requiredEnemies = 1; // ���������� ����������� ������.
    private int currentEnemies; // ������� ���������� ������.

    public Text doorText; // ������ �� ��������� �������, ������������ ���������� ���������� ������.

    private void Start()
    {
        currentEnemies = requiredEnemies;
        UpdateDoorText();
    }

    public void EnemyDestroyed()
    {
        if (currentEnemies > 0)
        {
            currentEnemies--;
            UpdateDoorText();
        }

        if (currentEnemies == 0)
        {
            OpenDoor();
        }
    }

    private void UpdateDoorText()
    {
        if (doorText != null)
        {
            doorText.text = "Enemies Left: " + currentEnemies.ToString();
        }
    }

    private void OpenDoor()
    {
        // ����� �������� ���, ������� ������ ����������� ��� �������� �����.
        // ��������, ��������� �������� ��� ����, ����� ���������� �����.
        Destroy(gameObject);
    }
}
