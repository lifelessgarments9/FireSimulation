using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsCursor : MonoBehaviour
{
    public float moveSpeed = 5f;       // Скорость перемещения
    public LayerMask wallLayer;       // Слой для стен
    public float stoppingDistance = 0.5f;  // Расстояние до стены, на котором объект останавливается

    private Camera mainCamera;

    void Start()
    {
        // Получаем ссылку на основную камеру
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Получаем позицию курсора в мировых координатах
        Vector3 cursorWorldPosition = GetCursorWorldPosition();

        // Вычисляем направление движения
        Vector3 direction = (cursorWorldPosition - transform.position).normalized;

        // Проверяем наличие стены на пути
        if (!IsWallInDirection(direction))
        {
            // Перемещаем объект
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    Vector3 GetCursorWorldPosition()
    {
        // Получаем позицию курсора в пикселях
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Конвертируем её в мировые координаты
        Ray ray = mainCamera.ScreenPointToRay(mouseScreenPosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point; // Возвращаем точку пересечения луча с поверхностью
        }

        return transform.position; // Если курсор не направлен на поверхность, остаёмся на месте
    }

    bool IsWallInDirection(Vector3 direction)
    {
        // Проверяем наличие стены на заданном направлении
        Ray ray = new Ray(transform.position, direction);
        if (Physics.Raycast(ray, out RaycastHit hit, stoppingDistance, wallLayer))
        {
            return true; // Есть стена
        }
        return false; // Стен нет
    }
}

