using SceneRuleSet.Context;
using UnityEditor;
using UnityEngine;

namespace SceneRuleSet.Editors
{
    [CustomEditor(typeof(RuleSetContext))]
    public class RuleSetContextEditor : Editor
    {
        private const string ButtonText = "Apply Rules";

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GUILayout.Space(10);

            if (GUILayout.Button(ButtonText))
            {
                RuleSetContext context = (RuleSetContext)target;
                context.ApplyRules();
            }
        }
    }
}
