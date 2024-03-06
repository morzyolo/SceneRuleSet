using System.Collections.Generic;
using SceneRuleSet.Source.Providers;
using SceneRuleSet.Source.RuleSets;
using UnityEngine;

namespace SceneRuleSet.Source.RuleSetContexts
{
    public class MonoRuleSetContext : MonoBehaviour
    {
        [SerializeField] private List<MonoRuleSet> _ruleSets = new();

        public void ApplyRules()
        {
            ObjectProvider provider = new();

            foreach (var ruleSet in _ruleSets)
            {
                ruleSet.ApplyTo(provider);
            }
        }
    }
}
