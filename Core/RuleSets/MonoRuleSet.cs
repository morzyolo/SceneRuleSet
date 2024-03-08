using SceneRuleSet.Core.Providers;
using UnityEngine;

namespace SceneRuleSet.Core.RuleSets
{
    public abstract class MonoRuleSet : MonoBehaviour, IRuleSet
    {
        public abstract void ApplyTo(ObjectProvider provider);
    }
}
