using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public DoorController door; // —сылка на контроллер двери.

    private void OnDestroy()
    {
        if (door != null)
        {
            door.EnemyDestroyed();
        }
    }
}
