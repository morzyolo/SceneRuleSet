#if UNITY_EDITOR

using SceneRuleSet.Core.Context;
using UnityEditor;
using UnityEngine;

namespace SceneRuleSet.Editors
{
    [CustomEditor(typeof(MonoRuleSetContext))]
    public class RuleSetContextEditor : Editor
    {
        private const string ButtonText = "Apply Rules";

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GUILayout.Space(10);

            if (GUILayout.Button(ButtonText))
            {
                MonoRuleSetContext context = (MonoRuleSetContext)target;
                context.ApplyRules();
            }
        }
    }
}
#endif
