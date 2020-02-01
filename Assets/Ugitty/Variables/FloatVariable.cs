using UnityEngine;

namespace Ugitty.Variables
{
    [CreateAssetMenu(fileName = "New float variable", menuName = "Ugitty/Variables/Float Variable", order = 1)]
    public class FloatVariable : GameVariable
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public float Value;
        [Header("Reset options")]
        public bool ResetOnLoad = false;
        public float DefaultValue;

        public void OnEnable ()
        {
            if (!ResetOnLoad) return;

            Value = DefaultValue;
        }

        public void SetValue(float value)
        {
            Value = value;
        }

        public void SetValue(FloatVariable value)
        {
            Value = value.Value;
        }

        public void ApplyChange(float amount)
        {
            Value += amount;
        }

        public void ApplyChange(FloatVariable amount)
        {
            Value += amount.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}