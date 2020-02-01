using UnityEngine;
using System;

namespace Ugitty.Events
{
    public abstract class GameEventPayloadSchema : ScriptableObject
    {
        public T GetPayload<T>()
        {
            return (T)Convert.ChangeType(this, typeof(T));
        }
    }
}