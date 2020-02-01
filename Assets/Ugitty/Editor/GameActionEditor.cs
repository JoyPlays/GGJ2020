using UnityEngine;
using UnityEditor;
using Ugitty.Events;

namespace TreasureHunter.EditorExtensions
{
    [CustomEditor(typeof(GameAction))]
    public class GameActionEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            GameAction e = target as GameAction;

            if (GUILayout.Button("Raise"))
            {
                e.Raise();
            }
        }
    }
}