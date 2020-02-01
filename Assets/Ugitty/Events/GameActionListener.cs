using UnityEngine;
using UnityEngine.Events;

namespace Ugitty.Events
{
    public class GameActionListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameAction Action;

        [Tooltip("Response to invoke when Event is raised with given payload.")]
        public UnityEvent Response;

        private void OnEnable()
        {
            Action.RegisterListener(this);
        }

        private void OnDisable()
        {
            Action.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}