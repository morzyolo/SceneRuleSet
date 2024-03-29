using System.Collections.Generic;
using UnityEngine;

namespace SceneRuleSet.Core.Extensions
{
    public static class FindExtension
    {
        public static TType FindOrDefault<TType>(this List<GameObject> gameObjects) where TType : Component
        {
            Queue<Transform> transformQueue = gameObjects.ToTransformQueue();

            while (transformQueue.Count > 0)
            {
                Transform currentTransform = transformQueue.Dequeue();

                if (currentTransform.TryGetComponent(out TType component))
                    return component;

                currentTransform.AddChildrenToQueue(transformQueue);
            }

            return default;
        }

        public static List<TType> FindListOf<TType>(this List<GameObject> gameObjects) where TType : Component
        {
            Queue<Transform> transformQueue = gameObjects.ToTransformQueue();
            List<TType> result = new();

            while (transformQueue.Count > 0)
            {
                Transform currentTransform = transformQueue.Dequeue();

                if (currentTransform.TryGetComponent(out TType component))
                    result.Add(component);

                currentTransform.AddChildrenToQueue(transformQueue);
            }

            return result;
        }
    }
}
