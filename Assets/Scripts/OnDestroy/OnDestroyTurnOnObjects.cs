using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyTurnOnObjects : MonoBehaviour
{
    public GameObject[] objectsToEnable; // ������ �������� ��� ��������� ����� ����������� �������� �������.
    public GameObject[] objectsToDisable; // ������ �������� ��� ���������� ����� ����������� �������� �������.

    private void OnDestroy()
    {
        // ���������, ���� �� ������� ��� ���������.
        if (objectsToEnable != null && objectsToEnable.Length > 0)
        {
            // �������� �� ������� � �������� ������ ������.
            foreach (GameObject obj in objectsToEnable)
            {
                obj.SetActive(true);
            }
        }

        // ���������, ���� �� ������� ��� ����������.
        if (objectsToDisable != null && objectsToDisable.Length > 0)
        {
            // �������� �� ������� � ��������� ������ ������.
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(false);
            }
        }
    }
}