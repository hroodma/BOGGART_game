using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 2f; // Скорость движения
    Transform A;
    Transform B;
    Transform targetWaypoint;
    private float t = 0f; // Параметр интерполяции

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
        // Плавно увеличиваем параметр t от 0 до 1
        t += speed * Time.deltaTime;

        // Используем Lerp для плавного перемещения между A и B
        transform.position = Vector3.Lerp(A.position, B.position, Mathf.PingPong(t, 1f));

        // Если враг достиг точки, переключаемся на следующую
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Меняем целевую точку
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

    // Метод для установки точек движения
    public void SetWaypoints(Transform spawnpoint, Transform waypoint)
    {
        A = spawnpoint;
        B = waypoint;
        targetWaypoint = B;
    }
}