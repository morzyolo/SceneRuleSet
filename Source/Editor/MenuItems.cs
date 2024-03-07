#if UNITY_EDITOR

using SceneRuleSet.Source.RuleSetContexts;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace SceneRuleSet.Source.Editor
{
    public static class MenuItems
    {
        [MenuItem("GameObject/SceneRuleSet/Rule Set Context", false, 12)]
        public static void CreateSceneRuleSet()
        {
            GameObject contextObject = new("Rule Set Context");
            MonoRuleSetContext context = contextObject.AddComponent<MonoRuleSetContext>();

            Selection.activeGameObject = context.gameObject;
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}
#endif
