using SceneRuleSet.Core.Providers;

namespace SceneRuleSet.Core.RuleSets
{
    public interface IRuleSet
    {
        public void ApplyTo(ObjectProvider provider);
    }
}
