using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // ������ �����
    public Slider sensitivitySlider; // ������� ����������������
    public Slider volumeSlider; // ������� �����

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // ���������� ����
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // ������������� ����
        isPaused = true;
    }

    public void SetSensitivity(float value)
    {
        // ����� �� ������ ���������� ���������������� ������ ���������
        Debug.Log("Sensitivity set to: " + value);
    }

    public void SetVolume(float value)
    {
        // ����� �� ������ ���������� ������� ��������� ������ �����
        Debug.Log("Volume set to: " + value);
    }

    public void OnSensitivitySliderChanged()
    {
        SetSensitivity(sensitivitySlider.value);
    }

    public void OnVolumeSliderChanged()
    {
        SetVolume(volumeSlider.value);
    }
}
