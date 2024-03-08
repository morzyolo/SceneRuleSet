#if UNITY_EDITOR

using SceneRuleSet.Core.Constants;
using SceneRuleSet.Core.Context;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace SceneRuleSet.EditorItems
{
    public static class MenuItems
    {
        private const string EditorOnlyTag = "EditorOnly";

        private const string DefaultMonoRuleSetFileName = "MonoRuleSetTemplate.txt";

        [MenuItem("GameObject/SceneRuleSet/Rule Set Context", false, 12)]
        public static void CreateSceneRuleSet()
        {
            GameObject contextObject = new(nameof(RuleSetContext)) {
                tag = EditorOnlyTag
            };
            var context = contextObject.AddComponent<RuleSetContext>();

            Selection.activeGameObject = context.gameObject;
            EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
        }

        [MenuItem("Assets/Create/SceneRuleSet/Mono Rule Set", false, 1)]
        public static void CreateDefaultMonoRuleSetFile()
        {
            string path = $"{PathConstants.PathToTemplates}/{DefaultMonoRuleSetFileName}";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, "DefaultRuleSet.cs");
        }
    }
}
#endif
