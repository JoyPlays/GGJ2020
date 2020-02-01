using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct MoveForwardComponent : IComponentData
{
    public float speed;
}