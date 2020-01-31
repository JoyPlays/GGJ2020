using UnityEngine;

namespace Ugitty.Events
{
    [CreateAssetMenu(fileName = "New game action", menuName = "Ugitty/Events/Action")]
    public class GameAction : BaseEvent<GameActionListener>, IDispatchable<GameActionListener>
    {
        public override void Dispatch(GameActionListener listener)
        {
            listener.OnEventRaised();
        }
    }
}