using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    // ������ �� ��������� AudioSource.
    private AudioSource audioSource;

    // �������� ��� ������� � ����� ������� �� ����� ����� ����� ����.
    private static BackgroundMusic instance;

    private void Awake()
    {
        // ���������, ���������� �� ��� ��������� ����� �������.
        if (instance == null)
        {
            // ���� ���, �� ���� ������ ���������� ����������� �������.
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ��������� ������ ��� ����� �������.
        }
        else
        {
            // ���� ��������� ��� ����������, ���������� ���� ������.
            Destroy(gameObject);
            return;
        }

        // �������� ��������� AudioSource.
        audioSource = GetComponent<AudioSource>();

        // ����� ����� ��������� ������ ��������� AudioSource, ��������, ���������� ��������� � ���������.
    }

    private void Start()
    {
        // �������� ��������������� ������.
        audioSource.Play();
    }
}
