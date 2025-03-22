using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // панель паузы
    public Slider sensitivitySlider; // слайдер чувствительности
    public Slider volumeSlider; // слайдер звука

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
        Time.timeScale = 1f; // продолжить игру
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // приостановить игру
        isPaused = true;
    }

    public void SetSensitivity(float value)
    {
        // Здесь вы можете установить чувствительность вашего персонажа
        Debug.Log("Sensitivity set to: " + value);
    }

    public void SetVolume(float value)
    {
        // Здесь вы можете установить уровень громкости вашего звука
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
