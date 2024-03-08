#if UNITY_EDITOR

using System.Collections.Generic;
using SceneRuleSet.Source.Providers;
using SceneRuleSet.Source.RuleSets;
using UnityEngine;

namespace SceneRuleSet.Context
{
    public class RuleSetContext : MonoBehaviour
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
#endif
