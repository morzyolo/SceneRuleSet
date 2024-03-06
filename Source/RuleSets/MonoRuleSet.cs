using SceneRuleSet.Source.Providers;
using UnityEngine;

namespace SceneRuleSet.Source.RuleSets
{
    public abstract class MonoRuleSet : MonoBehaviour, IRuleSet
    {
        public abstract void ApplyTo(ObjectProvider provider);
    }
}
