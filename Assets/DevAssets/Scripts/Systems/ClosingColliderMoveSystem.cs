using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

public class ClosingColliderMoveSystem : JobComponentSystem
{
    [RequireComponentTag(typeof(ClosingColliderComponent))]

    struct TurnJob : IJobForEach <Translation, MoveForwardComponent>
    {
        public float3 endPointPosition;
        public float dT;

        public void Execute(ref Translation pos, ref MoveForwardComponent data)
        {
            float3 heading = endPointPosition - pos.Value;
            heading.y = 0f;
            pos.Value += heading * data.speed * dT;
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new TurnJob
        {
            dT = UnityEngine.Time.deltaTime,
            endPointPosition = Vector3.zero
        };

        return job.Schedule(this, inputDeps);
    }
}