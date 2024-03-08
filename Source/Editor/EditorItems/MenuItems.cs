#if UNITY_EDITOR

using SceneRuleSet.Context;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace SceneRuleSet.EditorItems
{
    public static class MenuItems
    {
        private const string EditorOnlyTag = "EditorOnly";

        [MenuItem("GameObject/SceneRuleSet/Rule Set Context", false, 12)]
        public static void CreateSceneRuleSet()
        {
            GameObject contextObject = new("Rule Set Context") {
                tag = EditorOnlyTag
            };
            var context = contextObject.AddComponent<RuleSetContext>();

            Selection.activeGameObject = context.gameObject;
            EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
        }
    }
}
#endif
