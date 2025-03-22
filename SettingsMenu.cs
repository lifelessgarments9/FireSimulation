using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenu; // Ссылка на меню настроек
    public GameObject mainMenuObj;  // Ссылка на главное меню
    public Button exitSettingsButton;


    public Slider volumeSlider; // Ссылка на слайдер громкости
    void Start()
    {
        if (settingsMenu == null || mainMenuObj == null || exitSettingsButton == null)
        {
            Debug.LogError("⚠️ Ошибка: Проверь ссылки на объекты в инспекторе!");
            return;
        }

        settingsMenu.SetActive(false);
        exitSettingsButton.onClick.AddListener(CloseSettings);


        // Загружаем сохранённую громкость
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        volumeSlider.value = savedVolume;

        // Вызываем метод при изменении слайдера
        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    public void CloseSettings()
    {
        Debug.Log("📌 Закрываем настройки");
        settingsMenu.SetActive(false);
        mainMenuObj.SetActive(true);
    }

    public void ChangeVolume()
    {
        float newVolume = volumeSlider.value;

        // Находим фоновую музыку и меняем громкость
        BackgroundMusic music = FindFirstObjectByType<BackgroundMusic>();

        if (music != null)
        {
            music.SetVolume(newVolume);
        }
    }
}
