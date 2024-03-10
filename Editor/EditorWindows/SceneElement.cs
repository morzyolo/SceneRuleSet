using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace SceneRuleSet.EditorWindows
{
    public sealed class SceneElement
    {
        private readonly SceneAsset _sceneAsset;
        private readonly string _path;

        public SceneElement(SceneAsset sceneAsset, string path)
        {
            _sceneAsset = sceneAsset;
            _path = path;
        }

        public void Bind(VisualElement element)
        {
            Renamelabel(element, "SceneName", _sceneAsset.name);
            Renamelabel(element, "ScenePath", _path);

            Button applyButton = element.Q<Button>("ApplyRuleSetButton");
            applyButton.RegisterCallback<ClickEvent>(ApplyRuleSet);
        }

        public void Unbind(VisualElement element)
        {
            Button applyButton = element.Q<Button>("ApplyRuleSetButton");
            applyButton.UnregisterCallback<ClickEvent>(ApplyRuleSet);
        }

        public void ApplyRuleSet() => ApplyRuleSet(null);

        private void ApplyRuleSet(ClickEvent clickEvent)
        {

        }

        private void Renamelabel(VisualElement element, string labelName, string text)
        {
            Label sceneName = element.Q<Label>(labelName);
            sceneName.text = text;
            sceneName.tooltip = text;
        }
    }
}
