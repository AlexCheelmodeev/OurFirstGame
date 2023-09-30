using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public DoorController door; // ������ �� ���������� �����.

    private void OnDestroy()
    {
        if (door != null)
        {
            door.EnemyDestroyed();
        }
    }
}
