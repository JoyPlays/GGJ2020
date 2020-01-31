using UnityEngine;

namespace Ugitty.Events
{
    [CreateAssetMenu(fileName = "New game event", menuName = "Ugitty/Events/Event")]
    public class GameEvent : BaseEvent<GameEventListener>, IDispatchable<GameEventListener>
    {
        public GameEventPayloadSchema schema;

        public override void Dispatch(GameEventListener listener)
        {
            listener.OnEventRaised(schema);
        }
    }
}