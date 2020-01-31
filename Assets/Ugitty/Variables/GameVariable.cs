using UnityEngine;
using System;

namespace Ugitty.Variables
{
    public class GameVariable : ScriptableObject
    {
        public override string ToString()
        {
            return this.ToString();
        }

        public T GetValue<T>()
        {
            return (T)Convert.ChangeType(ToString(), typeof(T));
        }
    }
}