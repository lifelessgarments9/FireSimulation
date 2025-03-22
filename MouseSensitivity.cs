using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivity : MonoBehaviour
{
    public Slider sensitivitySlider; // ������ �� ������� ����������������

    private void Start()
    {
        // ��������� ���������� �������� ����������������
        float savedSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 2.0f);
        sensitivitySlider.value = savedSensitivity;

        // ��������� ���������� ��������� ��������
        sensitivitySlider.onValueChanged.AddListener(SetSensitivity);
    }

    public void SetSensitivity(float value)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", value);
        PlayerPrefs.Save(); // ��������� � PlayerPrefs
        Debug.Log("���������������� ���� ���������: " + value);
    }
}
