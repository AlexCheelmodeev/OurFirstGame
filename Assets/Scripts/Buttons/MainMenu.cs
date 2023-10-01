using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject creatorsPanel; // ������ �� ������ � ����������� � ����������.
    [SerializeField] private GameObject controlsPanel; // ������ �� ������ � �����������.

    private bool creatorsPanelActive = false; // ����, ������������, ������� �� ������ ����������.
    private bool controlsPanelActive = false; // ����, ������������, ������� �� ������ ����������.

    private void Start()
    {
        // ���������� �������� ������ � ����������� � ���������� � �����������.
        creatorsPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void StartGame()
    {
        // ��������� ������ ������� (��� ������ �������, ������� �� ������ ������������ ��� ������ ����).
        SceneManager.LoadScene("Level1"); // �������� "Level1" �� ��� ������ ������.
    }

    public void ShowCreators()
    {
        // ����������� ��������� ������ � ����������� � ����������.
        creatorsPanelActive = !creatorsPanelActive;
        creatorsPanel.SetActive(creatorsPanelActive);
    }

    public void ShowControls()
    {
        // ����������� ��������� ������ � �����������.
        controlsPanelActive = !controlsPanelActive;
        controlsPanel.SetActive(controlsPanelActive);
    }

    public void QuitGame()
    {
        // ����� �� ���� (�������� � ������ ����������).
        Application.Quit();
    }
}
