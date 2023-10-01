using UnityEngine;
using UnityEngine.UI;

public class PlayMusicOnClick : MonoBehaviour
{
    public AudioSource audioSource; // Ссылка на компонент AudioSource, в котором находится музыка.

    private void Start()
    {
        // Находим компонент AudioSource в дочерних объектах (возможно, у вас есть дополнительные объекты, которые содержат музыку).
        audioSource = GetComponentInChildren<AudioSource>();

        // Отключаем музыку при старте, чтобы она не проигрывалась автоматически.
        audioSource.Stop();
    }

    public void PlayMusic()
    {
        // Проверяем, активна ли музыка. Если активна, выключаем её. Если выключена, включаем.
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
    }
}
