using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTrigger : MonoBehaviour
{
    public GameObject canvasToOpen; // —сылка на Canvas, который вы хотите открыть.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // јктивируйте Canvas, чтобы открыть его.
            if (canvasToOpen != null)
            {
                canvasToOpen.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
