using UnityEngine;
using TMPro;
using Ugitty.Variables;

namespace Ugitty.Components
{
    public class UITextSetter : MonoBehaviour
    {
        public TextMeshProUGUI Handler;
        public GameVariable Variable;

        public void OnCurrencyChanged()
        {
            Handler.text = Variable.ToString();
        }
    }
}