using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpread : MonoBehaviour
{
    public GameObject firePrefab; // Префаб огня
    public float spreadDelay = 1f; // Задержка между волнами распространения
    public float spreadRadius = 2f; // Расстояние между соседними огнями
    public LayerMask obstacleLayer; // Слой для стен и препятствий

    public static int maxFireCount = 100; // Максимальное количество очагов огня
    private static int currentFireCount = 0; // Текущее количество огня
    private static HashSet<Vector3> burnedPositions = new HashSet<Vector3>(); // Контроль распространения

    void Start()
    {
        if (firePrefab == null)
        {
            Debug.LogError("FireSpread: firePrefab не назначен!");
            enabled = false; // Отключаем скрипт, если префаб не назначен
            return;
        }

        StartCoroutine(SpreadFire());
    }

    IEnumerator SpreadFire()
    {
        // Задержка перед каждой волной распространения
        yield return new WaitForSeconds(spreadDelay);

        // Если достигнуто максимальное количество огня, остановить распространение
        if (currentFireCount >= maxFireCount) yield break;

        // Возможные направления распространения
        Vector3[] directions = {
            Vector3.forward, Vector3.back, Vector3.left, Vector3.right
        };

        foreach (Vector3 direction in directions)
        {
            Vector3 spawnPosition = transform.position + direction * spreadRadius;

            // Проверяем, что огонь еще не появился в этой позиции
            if (burnedPositions.Contains(spawnPosition)) continue;

            // Проверяем наличие препятствий в направлении распространения
            if (!Physics.Raycast(transform.position, direction, spreadRadius, obstacleLayer))
            {
                // Добавляем новую позицию в список уже горящих
                burnedPositions.Add(spawnPosition);

                // Создаем новый объект огня
                GameObject newFire = Instantiate(firePrefab, spawnPosition, Quaternion.identity);

                // Назначаем новым огням родителя (комната)
                newFire.transform.parent = transform.parent;

                // Увеличиваем счетчик текущего огня
                currentFireCount++;

                // Добавляем к клонированному огню возможность распространяться дальше
                newFire.AddComponent<FireSpread>();
            }
        }
    }
}
