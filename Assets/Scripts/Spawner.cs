using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public List<Transform> SpawnPointsItem;
    public Transform SpawnPointPlayer;
    public Transform SpawnPointEnemy;

    void Start()
    {
        Instantiate(prefabs[0], SpawnPointPlayer.position, SpawnPointPlayer.rotation);
    }

    void Update()
    {
        
    }
}
