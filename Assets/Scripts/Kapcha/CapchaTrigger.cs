using UnityEngine;

public class CapchaTrigger : MonoBehaviour
{
    public Canvas canvasToClose; // ������������ Canvas, ������� �� ������ �������.
    public Animator doorAnimator; // ������������ �������� �����.
    public Animator animator; // ������������ �������� � ��������� "Wrong".

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
