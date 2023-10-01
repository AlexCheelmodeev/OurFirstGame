using UnityEngine;

public class CapchaTrigger : MonoBehaviour
{
    public Canvas canvasToClose; // ������������ Canvas, ������� �� ������ �������.
    public Animator doorAnimator; // ������������ �������� �����.
    public Animator animator; // ������������ �������� � ��������� "Wrong".

    public AudioSource correctAnswerAudioSource;
    public AudioSource wrongAnswerAudioSource;
    public AudioClip correctAnswerSound;
    public AudioClip wrongAnswerSound;

    public void CloseCanvasAndOpenDoor()
    {
        if (canvasToClose != null)
        {
            canvasToClose.gameObject.SetActive(false);
        }

        if (doorAnimator != null && correctAnswerAudioSource != null)
        {
            correctAnswerAudioSource.PlayOneShot(correctAnswerSound);
            doorAnimator.SetTrigger("IsOpening");
        }
    }

    public void ActivateAnimation()
    {
        if (animator != null && wrongAnswerAudioSource != null)
        {
            wrongAnswerAudioSource.PlayOneShot(wrongAnswerSound);
            animator.SetTrigger("Wrong");
        }
    }
}
