using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Ugitty.Audio
{
	[CustomEditor(typeof(AudioComposition), true)]
	public class AudioEventEditor : Editor
	{

		[SerializeField] private AudioSource _previewer;

		public void OnEnable()
		{
			_previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
		}

		public void OnDisable()
		{
			DestroyImmediate(_previewer.gameObject);
		}

		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
			if (GUILayout.Button("Preview"))
			{
				((AudioComposition)target).Play(_previewer);
			}
			EditorGUI.EndDisabledGroup();
		}
	}
}