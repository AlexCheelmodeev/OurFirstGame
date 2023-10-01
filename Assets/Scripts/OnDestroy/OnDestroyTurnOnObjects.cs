using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyTurnOnObjects : MonoBehaviour
{
    public GameObject[] objectsToEnable; // Массив объектов для включения после уничтожения текущего объекта.
    public GameObject[] objectsToDisable; // Массив объектов для выключения после уничтожения текущего объекта.

    private void OnDestroy()
    {
        // Проверяем, есть ли объекты для включения.
        if (objectsToEnable != null && objectsToEnable.Length > 0)
        {
            // Проходим по массиву и включаем каждый объект.
            foreach (GameObject obj in objectsToEnable)
            {
                obj.SetActive(true);
            }
        }

        // Проверяем, есть ли объекты для выключения.
        if (objectsToDisable != null && objectsToDisable.Length > 0)
        {
            // Проходим по массиву и выключаем каждый объект.
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(false);
            }
        }
    }
}