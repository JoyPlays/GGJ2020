using UnityEngine;
using Ugitty.Variables;
using System;

namespace Ugitty.Events.Schemas
{
    [CreateAssetMenu(fileName = "New event schema", menuName = "Ugitty/Events/Payloads/Game variables schema")]
    public class GameVariablesPayload : GameEventPayloadSchema
    {
        public ScalarEventValue[] Variables;

        [Serializable]
        public class ScalarEventValue
        {
            public string Name;
            public GameVariable Variable;
        }

        public GameVariable GetVariable(string name)
        {
            // Payload has to contain atleast 1 variable.
            if (Variables.Length == 0)
            {
                throw new Exception("Invalid schema for " + this.name + ". (Forgot to add varaibles?)");
            }

            // We don`t look for a variable when there is just one.
            if (Variables.Length == 1) return Variables[0].Variable;

            for (int i = 0; i <= Variables.Length-1; i++)
            {
                if (Variables[i].Name == name)
                {
                    return Variables[i].Variable;
                }
            }

            return Variables[0].Variable;
        }
    }
}
