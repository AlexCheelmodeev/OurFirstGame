using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    // Ссылка на компонент AudioSource.
    private AudioSource audioSource;

    // Синглтон для доступа к этому скрипту из любой части вашей игры.
    private static BackgroundMusic instance;

    private void Awake()
    {
        // Проверяем, существует ли уже экземпляр этого скрипта.
        if (instance == null)
        {
            // Если нет, то этот объект становится экземпляром скрипта.
            instance = this;
            DontDestroyOnLoad(gameObject); // Не разрушать объект при смене уровней.
        }
        else
        {
            // Если экземпляр уже существует, уничтожаем этот объект.
            Destroy(gameObject);
            return;
        }

        // Получаем компонент AudioSource.
        audioSource = GetComponent<AudioSource>();

        // Здесь можно настроить другие параметры AudioSource, например, установить аудиофайл и громкость.
    }

    private void Start()
    {
        // Начинаем воспроизведение музыки.
        audioSource.Play();
    }
}
