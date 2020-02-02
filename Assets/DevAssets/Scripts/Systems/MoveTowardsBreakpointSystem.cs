//using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

[UpdateAfter(typeof(MoveForwardComponent))]
public class MoveTowardsBreakpointSystem : JobComponentSystem
{
    [RequireComponentTag(typeof(MoveTowardsBreakpointComponent))]
    struct TurnJob : IJobForEach <Translation, PhysicsVelocity>
    {
        public float3 endPointPosition;
        public float dT;

        public void Execute(ref Translation pos, ref PhysicsVelocity vel)
        {
            float3 heading = endPointPosition - pos.Value;
            heading.y = 0f;
            
            float3 newVel = vel.Linear;
            newVel += heading * dT * 0.1f;
            vel.Linear = newVel;
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new TurnJob
        {
            dT = UnityEngine.Time.deltaTime,
            endPointPosition = The.gameLogic.pointToFall.position
        };

        return job.Schedule(this, inputDeps);
    }
}