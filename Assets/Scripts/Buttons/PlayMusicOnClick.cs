using UnityEngine;
using UnityEngine.UI;

public class PlayMusicOnClick : MonoBehaviour
{
    public AudioSource audioSource; // ������ �� ��������� AudioSource, � ������� ��������� ������.

    private void Start()
    {
        // ������� ��������� AudioSource � �������� �������� (��������, � ��� ���� �������������� �������, ������� �������� ������).
        audioSource = GetComponentInChildren<AudioSource>();

        // ��������� ������ ��� ������, ����� ��� �� ������������� �������������.
        audioSource.Stop();
    }

    public void PlayMusic()
    {
        // ���������, ������� �� ������. ���� �������, ��������� �. ���� ���������, ��������.
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
