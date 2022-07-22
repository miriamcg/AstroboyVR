using System.Collections;
using System.Collections.Generic;
using Astroboy.Asteroid;
using UnityEngine;
using UnityEditor;

namespace Astroboy.EditorExtensions
{
    [CustomEditor(typeof(GenerateField), true)]
    public class AsterioidInspector : Editor
    {
        protected GenerateField m_generateField;
        protected string m_currentMessage = "";

        protected void OnEnable()
        {
            m_generateField = (GenerateField)target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = EditorGUIUtility.currentViewWidth / 2;
            serializedObject.ApplyModifiedProperties();

            EditorGUILayout.LabelField("Field's Object", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(GenerateField.field)));
            EditorGUILayout.LabelField("Asteroid's Prefab", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(GenerateField.asteroid)));
            EditorGUILayout.LabelField("Radius of the Asteroid Field", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(GenerateField.fiedlRadius)));
            EditorGUILayout.LabelField("Seed of Asteroid count", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(GenerateField.asteroidCount)));
            EditorGUILayout.LabelField("Minimum size of the Asteroids", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(GenerateField.minimumSize)));
            EditorGUILayout.LabelField("Maximum size of the Asteroids", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(GenerateField.maximumSize)));

            EditorGUILayout.Space(20);

            if (GUILayout.Button("Generate Asteroids Field"))
            {
                if (m_generateField.asteroid.transform != null)
                {
                    m_currentMessage = "Generating";
                    m_generateField.GenerateAsteroids();
                }
            }

            EditorGUIUtility.labelWidth = 0;

            serializedObject.ApplyModifiedProperties();
        }
    }
}
