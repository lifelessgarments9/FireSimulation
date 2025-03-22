using UnityEngine;

public class FireLightFlicker : MonoBehaviour
{
    private Light fireLight;
    public float flickerSpeed = 1f; // �������� ��������
    public float intensityMin = 1f; // ����������� �������
    public float intensityMax = 3f; // ������������ �������

    void Start()
    {
        fireLight = GetComponent<Light>(); //����� ���������� ����
    }

    void Update()
    {
        fireLight.intensity = Mathf.Lerp(intensityMin, intensityMax, Mathf.PerlinNoise(Time.time * flickerSpeed, 0));
    }
}

