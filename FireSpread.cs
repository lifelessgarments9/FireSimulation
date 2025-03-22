using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpread : MonoBehaviour
{
    public GameObject firePrefab; // ������ ����
    public float spreadDelay = 1f; // �������� ����� ������� ���������������
    public float spreadRadius = 2f; // ���������� ����� ��������� ������
    public LayerMask obstacleLayer; // ���� ��� ���� � �����������

    public static int maxFireCount = 100; // ������������ ���������� ������ ����
    private static int currentFireCount = 0; // ������� ���������� ����
    private static HashSet<Vector3> burnedPositions = new HashSet<Vector3>(); // �������� ���������������

    void Start()
    {
        if (firePrefab == null)
        {
            Debug.LogError("FireSpread: firePrefab �� ��������!");
            enabled = false; // ��������� ������, ���� ������ �� ��������
            return;
        }

        StartCoroutine(SpreadFire());
    }

    IEnumerator SpreadFire()
    {
        // �������� ����� ������ ������ ���������������
        yield return new WaitForSeconds(spreadDelay);

        // ���� ���������� ������������ ���������� ����, ���������� ���������������
        if (currentFireCount >= maxFireCount) yield break;

        // ��������� ����������� ���������������
        Vector3[] directions = {
            Vector3.forward, Vector3.back, Vector3.left, Vector3.right
        };

        foreach (Vector3 direction in directions)
        {
            Vector3 spawnPosition = transform.position + direction * spreadRadius;

            // ���������, ��� ����� ��� �� �������� � ���� �������
            if (burnedPositions.Contains(spawnPosition)) continue;

            // ��������� ������� ����������� � ����������� ���������������
            if (!Physics.Raycast(transform.position, direction, spreadRadius, obstacleLayer))
            {
                // ��������� ����� ������� � ������ ��� �������
                burnedPositions.Add(spawnPosition);

                // ������� ����� ������ ����
                GameObject newFire = Instantiate(firePrefab, spawnPosition, Quaternion.identity);

                // ��������� ����� ����� �������� (�������)
                newFire.transform.parent = transform.parent;

                // ����������� ������� �������� ����
                currentFireCount++;

                // ��������� � �������������� ���� ����������� ���������������� ������
                newFire.AddComponent<FireSpread>();
            }
        }
    }
}
