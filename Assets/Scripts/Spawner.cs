using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemyController enemyController; // ������ �� EnemyController
    public List<GameObject> prefabs; // ������� ��� ������
    public List<Transform> SpawnPointsItem; // ����� ������ ��������� (�� ������������ �����)
    public Transform SpawnPointPlayer; // ����� ������ ������
    public List<Transform> spawnPointsEnemy; // ����� ������ ������
    public List<Transform> waypoints;

    void Start()
    {
        // ������� ������
        Instantiate(prefabs[0], SpawnPointPlayer.position, SpawnPointPlayer.rotation);

        // ������� ������
        for (int i = 0; i < spawnPointsEnemy.Count; i++)
        {
            GameObject enemy = Instantiate(prefabs[1], spawnPointsEnemy[i].position, spawnPointsEnemy[i].rotation);
            Enemy enemyScript = enemy.GetComponent<Enemy>();

            // ��������� ���������� ����� �������� ��� ����� �����
            if (enemyScript != null && i < waypoints.Count)
            {
                enemyScript.SetWaypoints(spawnPointsEnemy[i], waypoints[i]);
            }
        }
    }
}