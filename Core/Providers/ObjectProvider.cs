using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneRuleSet.Core.Providers
{
    public class ObjectProvider
    {
        public List<GameObject> Roots { get; }

        public ObjectProvider(Scene objectScene)
        {
            Roots = objectScene.GetRootGameObjects().ToList();
        }
    }
}
