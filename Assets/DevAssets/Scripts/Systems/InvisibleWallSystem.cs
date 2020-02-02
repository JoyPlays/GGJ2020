//using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class InvisibleWallSystem : JobComponentSystem
{
	[RequireComponentTag(typeof(InvisibleWallComponent))]
	struct TurnJob : IJobForEach <Translation>
	{
		public float endHeight;
		public float dT;

		public void Execute(ref Translation pos)
		{
			float3 newPos = pos.Value;
			newPos.y = endHeight;
			pos.Value = newPos;
		}
	}
    
	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		var job = new TurnJob
		{
			dT = UnityEngine.Time.deltaTime,
			endHeight = The.gameLogic.pointToFall.position.y
		};

		return job.Schedule(this, inputDeps);
	}
}