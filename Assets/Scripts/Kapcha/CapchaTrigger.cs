using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapchaTrigger : MonoBehaviour
{
    public Canvas canvasToClose; // Присоедините Canvas, который вы хотите закрыть.
    public Animator animator; // Присоедините аниматор с триггером "Wrong".

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
