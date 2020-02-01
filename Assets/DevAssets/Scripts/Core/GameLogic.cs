using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject zombiePrefab;

    public Transform zombieSpawnPoint;
    public Transform zombieEndPoint;
    
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
    
    void SpawnZombies()
    {
        for (int i = 0; i < 1000; i++)
        {
            Entity zombie = manager.Instantiate(zombieEntityPrefab);
            Vector3 dir = (zombieEndPoint.position - zombieSpawnPoint.position).normalized;
            Quaternion rot = Quaternion.LookRotation(dir);
            manager.SetComponentData(zombie, new Translation{Value = zombieSpawnPoint.position});
            manager.SetComponentData(zombie, new Rotation{Value = rot});
            manager.AddComponentData(zombie, new ZombieTagComponent());

            // Vector3 dir = (zombieEndPoint.position - zombieSpawnPoint.position).normalized;
            // Vector3 speed = dir * 1f;


            // PhysicsVelocity velocity = new PhysicsVelocity()
            // {
            //     Linear = speed,
            //     Angular = float3.zero
            // };
            //
            // manager.AddComponentData(zombie, velocity);
        }
    }
}
