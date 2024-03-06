using SceneRuleSet.Source.Providers;

namespace SceneRuleSet.Source.RuleSets
{
    public interface IRuleSet
    {
        public void ApplyTo(ObjectProvider provider);
    }
}
