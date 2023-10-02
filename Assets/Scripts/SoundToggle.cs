using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    private bool isSoundOn = true; // ����, �����������, ������� �� ����.
    public Button soundOnButton; // ������ �� ������ ��������� �����.
    public Button soundOffButton; // ������ �� ������ ���������� �����.
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

        // ������������� ��������� ��������� ������ � ����������� �� isSoundOn.
        soundOnButton.interactable = !isSoundOn;
        soundOffButton.interactable = isSoundOn;
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

        // ��������� ���������� ������.
        soundOnButton.interactable = !isSoundOn;
        soundOffButton.interactable = isSoundOn;
    }
}
