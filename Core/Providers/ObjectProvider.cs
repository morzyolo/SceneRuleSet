using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneRuleSet.Core.Providers
{
    public class ObjectProvider
    {
        public GameObject[] Roots { get; }

        public ObjectProvider(Scene objectScene)
        {
            Roots = objectScene.GetRootGameObjects();
        }
    }
}
