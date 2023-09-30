using UnityEngine;

public class BarkButton : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator; // Ссылка на аниматор игрока.
    [SerializeField] private AudioClip buttonSound; // Звук, который будет проигрываться при нажатии кнопки E.

    private void Update()
    {
        // Проверяем, нажата ли клавиша "E".
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Проверяем наличие аниматора игрока.
            if (playerAnimator != null)
            {
                // Проигрываем триггер "ISTriggered" в аниматоре игрока.
                playerAnimator.SetTrigger("IsTriggered");
            }

            // Проверяем наличие звука.
            if (buttonSound != null)
            {
                // Проигрываем аудиофайл, привязанный к персонажу.
                AudioSource audioSource = GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.clip = buttonSound;
                    audioSource.Play();
                }
            }
        }
    }
}
