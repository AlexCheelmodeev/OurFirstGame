using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTrigger : MonoBehaviour
{
    public GameObject canvasToOpen; // ������ �� Canvas, ������� �� ������ �������.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ����������� Canvas, ����� ������� ���.
            if (canvasToOpen != null)
            {
                canvasToOpen.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
