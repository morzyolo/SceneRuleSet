#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace SceneRuleSet.EditorWindows
{
    public class RuleSetContextInvokerWindow : EditorWindow
    {
        private const string FolderPathPrefKey = "FolderPath";

        [SerializeField] private VisualTreeAsset _tree;
        [SerializeField] private VisualTreeAsset _sceneElement;

        private List<SceneElement> _currentScenes;
        private List<SceneElement> _oldScenes;

        private TextField _folderTextField;
        private Button _refreshSceneListButton;
        private Button _applyAllRuleSetsButton;
        private ListView _sceneListView;

        private void Awake()
        {
            _tree.CloneTree(rootVisualElement);

            InitializeElements();
        }

        private void OnEnable()
        {
            if (EditorPrefs.HasKey(FolderPathPrefKey))
                _folderTextField.value = EditorPrefs.GetString(FolderPathPrefKey);

            _refreshSceneListButton.RegisterCallback<ClickEvent>(RefreshSceneList);
            _applyAllRuleSetsButton.RegisterCallback<ClickEvent>(ApplyAllRuleSets);

            RefreshSceneList();
        }

        private void OnDisable()
        {
            EditorPrefs.SetString(FolderPathPrefKey, _folderTextField.value);

            _refreshSceneListButton.UnregisterCallback<ClickEvent>(RefreshSceneList);
            _applyAllRuleSetsButton.UnregisterCallback<ClickEvent>(ApplyAllRuleSets);
        }

        private void InitializeElements()
        {
            _folderTextField = rootVisualElement.Q<TextField>("FolderTextField");
            _refreshSceneListButton = rootVisualElement.Q<Button>("RefreshSceneListButton");
            _applyAllRuleSetsButton = rootVisualElement.Q<Button>("ApplyAllRuleSetsButton");
            _sceneListView = rootVisualElement.Q<ListView>("SceneListView");

            _sceneListView.itemsSource = _currentScenes;
            _sceneListView.makeItem = CreateNewSceneElement;

            _sceneListView.bindItem = BindSceneElement;
            _sceneListView.unbindItem = UnbindSceneElement;
        }

        private VisualElement CreateNewSceneElement()
        {
            TemplateContainer elementClone = _sceneElement.CloneTree();
            return elementClone.Q<VisualElement>("SceneViewElement");
        }

        private void BindSceneElement(VisualElement element, int index)
        {
            _currentScenes[index].Bind(element);
        }

        private void UnbindSceneElement(VisualElement element, int index)
        {
            _oldScenes[index].Unbind(element);
        }

        private void RefreshSceneList(ClickEvent clickEvent = null)
        {
            string folderPath = _folderTextField.value;

            string[] sceneGUIDs = AssetDatabase.FindAssets("t:Scene", new[] { folderPath });
            string[] scenePaths = sceneGUIDs.Select(AssetDatabase.GUIDToAssetPath).ToArray();

            _oldScenes = _currentScenes;
            _currentScenes = new(scenePaths.Length);

            foreach (string path in scenePaths)
            {
                SceneAsset sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(path);
                _currentScenes.Add(new SceneElement(sceneAsset.name, path));
            }

            _sceneListView.itemsSource = _currentScenes;
        }

        private void ApplyAllRuleSets(ClickEvent evt)
        {
            foreach (SceneElement element in _currentScenes)
            {
                element.ApplyRuleSet();
            }
        }
    }
}
#endif
