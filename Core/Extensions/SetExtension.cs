using System;
using System.Collections.Generic;

namespace SceneRuleSet.Core.Extensions
{
    public static class SetExtension
    {
        public static List<TType> Set<TType>(this List<TType> list, Action<TType> set)
        {
            foreach (TType type in list)
            {
                set(type);
            }

            return list;
        }
    }
}
