using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapchaTrigger : MonoBehaviour
{
    public Canvas canvasToClose; // ������������ Canvas, ������� �� ������ �������.
    public Animator animator; // ������������ �������� � ��������� "Wrong".

    public void CloseCanvas()
    {
        if (canvasToClose != null)
        {
            canvasToClose.gameObject.SetActive(false);
        }
    }

    public void ActivateAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Wrong");
        }
    }
}
