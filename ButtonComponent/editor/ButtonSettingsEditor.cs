using UnityEditor;

namespace alisahanyalcin.UI.Button
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ButtonSettings))]
    public class ButtonSettingsEditor : Editor
    {
        private SerializedProperty _useColor;
        private SerializedProperty _images;
        private SerializedProperty _texts;
        private SerializedProperty _normalColor;
        private SerializedProperty _hoverColor;
        private SerializedProperty _pressedColor;
        
        private void OnEnable()
        {
            _useColor = serializedObject.FindProperty("useColor");
            _images = serializedObject.FindProperty("images");
            _texts = serializedObject.FindProperty("texts");
            _normalColor = serializedObject.FindProperty("normalColor");
            _hoverColor = serializedObject.FindProperty("hoverColor");
            _pressedColor = serializedObject.FindProperty("pressedColor");
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUILayout.LabelField("Button Colors", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_useColor);
            
            if (_useColor.boolValue)
            {
                EditorGUILayout.PropertyField(_images);
                EditorGUILayout.PropertyField(_texts);
                EditorGUILayout.PropertyField(_normalColor);
                EditorGUILayout.PropertyField(_hoverColor);
                EditorGUILayout.PropertyField(_pressedColor);
            }
            
            EditorGUILayout.Space();
            serializedObject.ApplyModifiedProperties();
        }
    }
}