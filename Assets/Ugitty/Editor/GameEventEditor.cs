using UnityEngine;
using UnityEditor;
using Ugitty.Events;

namespace Ugitty.EditorExtensions
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            GameEvent e = target as GameEvent;

            if (e.schema) {

                GUIStyle labelStyle = new GUIStyle
                {
                    fontSize = 12,
                    fontStyle = FontStyle.Bold,
                };
                labelStyle.normal.textColor = Color.white;

                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();

                EditorGUI.LabelField(new Rect(15, 45, 100, 20), "Payload schema", labelStyle);

                SerializedProperty selectedPayload = serializedObject.FindProperty("schema");
                Editor subEditor = CreateEditor(selectedPayload.objectReferenceValue);
                subEditor.OnInspectorGUI();
            }

            serializedObject.ApplyModifiedProperties();

            this.DrawEventRaiseButton(e);
        }

        private void DrawEventRaiseButton(GameEvent e)
        {
            if (GUILayout.Button("Raise")) {
                e.Raise();
            }
        }
    }
}