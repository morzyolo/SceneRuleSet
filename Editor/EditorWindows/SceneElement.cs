#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using SceneRuleSet.Core.Context;
using SceneRuleSet.Core.Extensions;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace SceneRuleSet.EditorWindows
{
    public sealed class SceneElement
    {
        private readonly string _name;
        private readonly string _path;

        public SceneElement(string name, string path)
        {
            _name = name;
            _path = path;
        }

        public void Bind(VisualElement element)
        {
            Renamelabel(element, "SceneName", _name);
            Renamelabel(element, "ScenePath", _path);

            Button applyButton = element.Q<Button>("ApplyRuleSetButton");
            applyButton.RegisterCallback<ClickEvent>(ApplyRuleSet);
        }

        public void Unbind(VisualElement element)
        {
            Button applyButton = element.Q<Button>("ApplyRuleSetButton");
            applyButton.UnregisterCallback<ClickEvent>(ApplyRuleSet);
        }

        public void ApplyRuleSet(ClickEvent clickEvent) => ApplyRuleSet();

        public void ApplyRuleSet()
        {
            bool isValid = IsValidScene(_path);

            Scene scene = EditorSceneManager.OpenScene(_path, OpenSceneMode.Additive);
            List<GameObject> roots = scene.GetRootGameObjects().ToList();
            var context = roots.FindOrDefault<MonoRuleSetContext>();

            if (context is null)
            {
                Debug.LogWarning($"The \"{scene.name}\" does not contain a RuleSetContext");
            }
            else
            {
                context.ApplyRules();

                EditorSceneManager.MarkSceneDirty(scene);
                EditorSceneManager.SaveScene(scene);

                Debug.Log($"Set of rules was applied to the {scene.name}.");
            }

            if (!isValid)
                EditorSceneManager.CloseScene(scene, true);
        }

        private bool IsValidScene(string path)
        {
            Scene scene = SceneManager.GetSceneByPath(path);
            return scene.IsValid();
        }

        private void Renamelabel(VisualElement element, string labelName, string text)
        {
            Label sceneName = element.Q<Label>(labelName);
            sceneName.text = text;
            sceneName.tooltip = text;
        }
    }
}
#endif
