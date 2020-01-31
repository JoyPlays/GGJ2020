using UnityEngine;

namespace Ugitty.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent Event;

        [Tooltip("Response to invoke when Event is raised with given payload.")]
        public PayloadableUnityEvent Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(GameEventPayloadSchema payload)
        {
            Response.Invoke(payload);
        }
    }
}