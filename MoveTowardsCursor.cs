using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsCursor : MonoBehaviour
{
    public float moveSpeed = 5f;       // �������� �����������
    public LayerMask wallLayer;       // ���� ��� ����
    public float stoppingDistance = 0.5f;  // ���������� �� �����, �� ������� ������ ���������������

    private Camera mainCamera;

    void Start()
    {
        // �������� ������ �� �������� ������
        mainCamera = Camera.main;
    }

    void Update()
    {
        // �������� ������� ������� � ������� �����������
        Vector3 cursorWorldPosition = GetCursorWorldPosition();

        // ��������� ����������� ��������
        Vector3 direction = (cursorWorldPosition - transform.position).normalized;

        // ��������� ������� ����� �� ����
        if (!IsWallInDirection(direction))
        {
            // ���������� ������
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    Vector3 GetCursorWorldPosition()
    {
        // �������� ������� ������� � ��������
        Vector3 mouseScreenPosition = Input.mousePosition;

        // ������������ � � ������� ����������
        Ray ray = mainCamera.ScreenPointToRay(mouseScreenPosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point; // ���������� ����� ����������� ���� � ������������
        }

        return transform.position; // ���� ������ �� ��������� �� �����������, ������� �� �����
    }

    bool IsWallInDirection(Vector3 direction)
    {
        // ��������� ������� ����� �� �������� �����������
        Ray ray = new Ray(transform.position, direction);
        if (Physics.Raycast(ray, out RaycastHit hit, stoppingDistance, wallLayer))
        {
            return true; // ���� �����
        }
        return false; // ���� ���
    }
}

