using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivity : MonoBehaviour
{
    public Slider sensitivitySlider; // Ссылка на слайдер чувствительности

    private void Start()
    {
        // Загружаем сохранённое значение чувствительности
        float savedSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 2.0f);
        sensitivitySlider.value = savedSensitivity;

        // Добавляем обработчик изменения слайдера
        sensitivitySlider.onValueChanged.AddListener(SetSensitivity);
    }

    public void SetSensitivity(float value)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", value);
        PlayerPrefs.Save(); // Сохраняем в PlayerPrefs
        Debug.Log("Чувствительность мыши сохранена: " + value);
    }
}
