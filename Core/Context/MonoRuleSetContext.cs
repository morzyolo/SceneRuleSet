using System.Collections.Generic;
using SceneRuleSet.Core.Providers;
using SceneRuleSet.Core.RuleSets;
using UnityEngine;

namespace SceneRuleSet.Core.Context
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
