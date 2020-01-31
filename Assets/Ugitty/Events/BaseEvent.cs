using System.Collections.Generic;
using UnityEngine;

namespace Ugitty.Events
{
    public abstract class BaseEvent<T> : ScriptableObject
    {
        protected List<T> listeners = new List<T>();

        public void RegisterListener(T listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void UnregisterListener(T listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }

        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                Dispatch(listeners[i]);
            }
        }

        public abstract void Dispatch(T listener);
    }
}