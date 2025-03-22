using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;
    private AudioSource audioSource;

    void Awake()
    {
        // Синглтон: делает так, чтобы музыка не прерывалась при смене сцен
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Оставляем объект при смене сцены
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();

        // Загружаем сохранённую громкость
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        audioSource.volume = savedVolume;
        audioSource.Play();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }
}


