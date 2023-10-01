using UnityEngine;

public class CapchaTrigger : MonoBehaviour
{
    public Canvas canvasToClose; // Присоедините Canvas, который вы хотите закрыть.
    public Animator doorAnimator; // Присоедините аниматор двери.
    public Animator animator; // Присоедините аниматор с триггером "Wrong".

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
