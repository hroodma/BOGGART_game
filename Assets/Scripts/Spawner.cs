using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemyController enemyController; // Ссылка на EnemyController
    public List<GameObject> prefabs; // Префабы для спавна
    public List<Transform> SpawnPointsItem; // Точки спавна предметов (не используются здесь)
    public Transform SpawnPointPlayer; // Точка спавна игрока
    public List<Transform> spawnPointsEnemy; // Точки спавна врагов
    public List<Transform> waypoints;

    void Start()
    {
        // Спавним игрока
        Instantiate(prefabs[0], SpawnPointPlayer.position, SpawnPointPlayer.rotation);

        // Спавним врагов
        for (int i = 0; i < spawnPointsEnemy.Count; i++)
        {
            GameObject enemy = Instantiate(prefabs[1], spawnPointsEnemy[i].position, spawnPointsEnemy[i].rotation);
            Enemy enemyScript = enemy.GetComponent<Enemy>();

            // Назначаем уникальные точки движения для этого врага
            if (enemyScript != null && i < waypoints.Count)
            {
                enemyScript.SetWaypoints(spawnPointsEnemy[i], waypoints[i]);
            }
        }
    }
}