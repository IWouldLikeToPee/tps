using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawnerController : MonoBehaviour
{
   public EnemyAI enemyPrefab;
   private float _timeLastSpawnend;
   public float delay = 5;
   public PlayerController player;
   public List<Transform> patrolPoints;

   private void Start()
   {
    SpawnEnemy();
   }

   private void Update()
   {
    if(Time.time - _timeLastSpawnend > delay)
    {
        SpawnEnemy();
        _timeLastSpawnend = Time.time;
    }
   }

   public void SpawnEnemy()
   {
    Instantiate(enemyPrefab, transform.position, transform.rotation);
    _timeLastSpawnend = Time.time;
    enemyPrefab.player = player;
    enemyPrefab.patrolPoints = patrolPoints;
   }


   
}
