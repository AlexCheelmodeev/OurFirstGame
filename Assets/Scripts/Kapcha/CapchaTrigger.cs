using UnityEngine;

public class CapchaTrigger : MonoBehaviour
{
    public Canvas canvasToClose; // Присоедините Canvas, который вы хотите закрыть.
    public Animator doorAnimator; // Присоедините аниматор двери.
    public Animator animator; // Присоедините аниматор с триггером "Wrong".

    public void CloseCanvasAndOpenDoor()
    {
        if (canvasToClose != null)
        {
            canvasToClose.gameObject.SetActive(false);
        }

        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("IsOpening");
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
