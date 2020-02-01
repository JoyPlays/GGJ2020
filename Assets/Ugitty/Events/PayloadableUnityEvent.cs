using UnityEngine.Events;

namespace Ugitty.Events
{
    [System.Serializable]
    public class PayloadableUnityEvent : UnityEvent<GameEventPayloadSchema> { }
}