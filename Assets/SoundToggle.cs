using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    private bool isSoundOn = true; // ����, �����������, ������� �� ����.

    private AudioSource backgroundMusic; // ������ �� ����� �������� ������� ������.

    private void Start()
    {
        // ������� ����� �������� ������� ������ �� ����� ����� �������� � ������ "AudioController".
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
            // �������� ����.
            if (backgroundMusic != null)
            {
                backgroundMusic.UnPause(); // ������������� ������� ������, ���� ��� ���� ��������������.
            }
        }
        else
        {
            // ��������� ����.
            if (backgroundMusic != null)
            {
                backgroundMusic.Pause(); // ���������������� ������� ������.
            }
        }
    }
}
