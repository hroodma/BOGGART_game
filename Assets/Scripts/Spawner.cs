using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs; // Префабы для спавна
    public Transform spawnPointPlayer; // Точка спавна игрока
    public List<Transform> spawnPointsEnemy; // Точки спавна врагов
    public List<Transform> waypoints; // Конечные точки движения врага
    public List<Transform> spawnPointsBonus; // Точки спавна бонусов
    public List<Transform> busySpawnPointsBonus;  // Занятые точки спавна бонусов

    void Start()
    {
        PlayerSpawn();
        EnemySpawn();
        BonusSpawn();
    }

    // Спавнер игрока
    void PlayerSpawn()
    {
        // Спавним игрока
        Instantiate(prefabs[0], spawnPointPlayer.position, spawnPointPlayer.rotation);
    }

    // Спавнер врагов
    void EnemySpawn()
    {
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
     // Спавнер бонусов
    void BonusSpawn()
    {
        //Спавним бонусы
        for (int i = 2; i < prefabs.Count; i++)
        {
            int random = Random.Range(0, spawnPointsBonus.Count);

            // Избежание появления нескольких бонусов в одном месте
            if (busySpawnPointsBonus.Contains(spawnPointsBonus[random]))
            {
                i--;
            }
            else
            {
                GameObject bonus = Instantiate(prefabs[i], spawnPointsBonus[random].position, spawnPointsBonus[random].rotation);
                busySpawnPointsBonus.Add(spawnPointsBonus[random]);
            }
        }
    }
}