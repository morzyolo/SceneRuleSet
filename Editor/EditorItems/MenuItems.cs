#if UNITY_EDITOR

using SceneRuleSet.Core.Constants;
using SceneRuleSet.Core.Context;
using SceneRuleSet.EditorWindows;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneRuleSet.EditorItems
{
    public static class MenuItems
    {
        private const string EditorOnlyTag = "EditorOnly";
        private const string RuleSetContextInvokerWindowName = "Rule Set Invoker";

        private const string DefaultMonoRuleSetFileName = "MonoRuleSetTemplate.txt";
        private const string DefaultNewRuleSetFileName = "DefaultRuleSet.cs";

        [MenuItem("GameObject/SceneRuleSet/Rule Set Context", false, 12)]
        public static void CreateRuleSetContext()
        {
            GameObject contextObject = new(nameof(MonoRuleSetContext)) {
                tag = EditorOnlyTag
            };
            var context = contextObject.AddComponent<MonoRuleSetContext>();

            Selection.activeGameObject = context.gameObject;
            EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
        }

        [MenuItem("Assets/Create/SceneRuleSet/Mono Rule Set", false, 1)]
        public static void CreateDefaultMonoRuleSetFile()
        {
            string path = $"{PathConstants.PathToTemplates}/{DefaultMonoRuleSetFileName}";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path, DefaultNewRuleSetFileName);
        }

        [MenuItem("Window/Rule Set Invoker")]
        public static void OpenRuleSetContextInvoker()
        {
            EditorWindow window = EditorWindow.GetWindow<RuleSetContextInvokerWindow>();
            window.titleContent = new GUIContent(RuleSetContextInvokerWindowName);
            window.minSize = new Vector2(280, 140);
        }
    }
}
#endif
