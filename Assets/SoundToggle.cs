using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    private bool isSoundOn = true; // Флаг, указывающий, включен ли звук.

    private AudioSource backgroundMusic; // Ссылка на аудио источник фоновой музыки.

    private void Start()
    {
        // Находим аудио источник фоновой музыки на сцене среди объектов с именем "AudioController".
        GameObject audioController = GameObject.Find("AudioController");
        if (audioController != null)
        {
            backgroundMusic = audioController.GetComponent<AudioSource>();
        }

        if (backgroundMusic == null)
        {
            Debug.LogWarning("Background music AudioSource not found.");
        }
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;

        if (isSoundOn)
        {
            // Включаем звук.
            if (backgroundMusic != null)
            {
                backgroundMusic.UnPause(); // Воспроизводим фоновую музыку, если она была приостановлена.
            }
        }
        else
        {
            // Выключаем звук.
            if (backgroundMusic != null)
            {
                backgroundMusic.Pause(); // Приостанавливаем фоновую музыку.
            }
        }
    }
}
