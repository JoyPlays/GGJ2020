//using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

[UpdateAfter(typeof(MoveForwardComponent))]
public class TurnTowardsEndPointSystem : JobComponentSystem
{
    [RequireComponentTag(typeof(ZombieTagComponent))]
    struct TurnJob : IJobForEach <Translation, Rotation, MoveForwardComponent>
    {
        public float3 endPointPosition;
        public float dT;

        public void Execute(ref Translation pos, ref Rotation rot, ref MoveForwardComponent moveData)
        {
            float3 heading = endPointPosition - pos.Value;
            heading.y = 0f;
            rot.Value = quaternion.LookRotation(heading, math.up());
            pos.Value += heading * moveData.speed * dT;
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new TurnJob
        {
            dT = UnityEngine.Time.deltaTime,
            endPointPosition = The.gameLogic.zombieEndPoint.position
        };

        return job.Schedule(this, inputDeps);
    }
}