using UnityEngine;

public class FireLightFlicker : MonoBehaviour
{
    private Light fireLight;
    public float flickerSpeed = 1f; // Скорость мерцания
    public float intensityMin = 1f; // Минимальная яркость
    public float intensityMax = 3f; // Максимальная яркость

    void Start()
    {
        fireLight = GetComponent<Light>(); //вызов компонента типа
    }

    void Update()
    {
        fireLight.intensity = Mathf.Lerp(intensityMin, intensityMax, Mathf.PerlinNoise(Time.time * flickerSpeed, 0));
    }
}

