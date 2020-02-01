using UnityEngine;

namespace Ugitty.Variables
{
    [CreateAssetMenu(fileName = "New string variable", menuName = "Ugitty/Variables/String Variable", order = 3)]
    public class StringVariable : GameVariable
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public string Value;
        [Header("Reset options")]
        public bool ResetOnLoad = false;
        public string DefaultValue;

        public void OnEnable()
        {
            if (!ResetOnLoad) return;

            Value = DefaultValue;
        }

        public void SetValue(string value)
        {
            Value = value;
        }

        public void SetValue(StringVariable value)
        {
            Value = value.Value;
        }

        public void Append(string AdditionalValue)
        {
            Value = Value + AdditionalValue;
        }

        public void Prepend(string AdditionalValue)
        {
            Value = AdditionalValue + Value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}