using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerBody;
    public float moveSpeed = 5f; // Скорость передвижения
    public float mouseSensitivity = 2.0f; // Чувствительность мыши (получаем от MouseSensitivity)
    public Transform cameraTransform; // Привязанная камера

    private float xRotation = 0f;

    void Start()
    {
        // Загружаем чувствительность из сохранений
        mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 2.0f);
        Debug.Log("Загруженная чувствительность мыши: " + mouseSensitivity);
    }

    void Update()
    {
        MovePlayer();
        RotateCamera();

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal"); // A / D
        float moveZ = Input.GetAxis("Vertical");   // W / S

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Ограничиваем поворот камеры вверх/вниз
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    // Метод для изменения чувствительности (вызывается из MouseSensitivity)
    public void SetMouseSensitivity(float sensitivity)
    {
        mouseSensitivity = sensitivity;
    }
}
