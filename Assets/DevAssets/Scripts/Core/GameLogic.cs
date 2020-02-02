using System;
using System.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameLogic : MonoBehaviour
{
    public GameObject zombiePrefab;
    public GameObject towerPrefab;

    public Transform zombieSpawnPoint;
    public Transform zombieEndPoint;
    public Transform pointToFall;
    
    private Entity zombieEntityPrefab;
    private EntityManager manager;
    
    private void Awake()
    {
        The.gameLogic = this;
        
        manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        
        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, new BlobAssetStore());
        zombieEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(zombiePrefab, settings);
        
        SpawnZombies();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //SpawnTower(Vector3.zero);
            SpawnZombies();
        }
    }

    void SpawnZombies()
    {
        StartCoroutine(SpawnSequence());
    }

    private IEnumerator SpawnSequence()
    {
        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Entity zombie = manager.Instantiate(zombieEntityPrefab);
                Vector3 dir = (zombieEndPoint.position - zombieSpawnPoint.position).normalized;
                Quaternion rot = Quaternion.LookRotation(dir);
                Vector3 rng = Random.insideUnitSphere * 25f;
                rng.y = 0f;
                manager.SetComponentData(zombie, new Translation{Value = zombieSpawnPoint.position + rng});
                manager.SetComponentData(zombie, new Rotation{Value = rot});
                manager.AddComponentData(zombie, new ZombieTagComponent());

                MoveForwardComponent moveForwardComponent = new MoveForwardComponent
                {
                    speed = Random.Range(0.05f, 0.15f)
                };
                manager.AddComponentData(zombie, moveForwardComponent);
            }
            yield return null;
        }
        
    }

    private void SpawnTower(Vector3 positionToSpawn)
    {
        Instantiate(towerPrefab, positionToSpawn, Quaternion.identity);
    }
}
