using UnityEngine;

namespace Ugitty.Variables
{
    [CreateAssetMenu(fileName = "New integer variable", menuName = "Ugitty/Variables/Integer Variable", order = 1)]
    public class IntVariable : GameVariable
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public int Value;
        [Header("Reset options")]
        public bool ResetOnLoad = false;
        public int DefaultValue;

        public void OnEnable()
        {
            if (!ResetOnLoad) return;

            Value = DefaultValue;
        }

        public void SetValue(int value)
        {
            Value = value;
        }

        public void SetValue(IntVariable value)
        {
            Value = value.Value;
        }

        public void ApplyChange(int amount)
        {
            Value += amount;
        }

        public void ApplyChange(IntVariable amount)
        {
            Value += amount.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}