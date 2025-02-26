using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 2f; // �������� ��������
    Transform A;
    Transform B;
    Transform targetWaypoint;
    private float t = 0f; // �������� ������������

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveBetweenWaypoints();
    }

    void MoveBetweenWaypoints()
    {
        // ������ ����������� �������� t �� 0 �� 1
        t += speed * Time.deltaTime;

        // ���������� Lerp ��� �������� ����������� ����� A � B
        transform.position = Vector3.Lerp(A.position, B.position, Mathf.PingPong(t, 1f));

        // ���� ���� ������ �����, ������������� �� ���������
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // ������ ������� �����
            if (targetWaypoint == A)
            {
                targetWaypoint = B;
            }
            else
            {
                targetWaypoint = A;
            }
        }
    }

    // ����� ��� ��������� ����� ��������
    public void SetWaypoints(Transform spawnpoint, Transform waypoint)
    {
        A = spawnpoint;
        B = waypoint;
        targetWaypoint = B;
    }
}