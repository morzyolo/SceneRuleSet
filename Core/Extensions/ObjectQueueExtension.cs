using System.Collections.Generic;
using UnityEngine;

namespace SceneRuleSet.Core.Extensions
{
    public static class ObjectQueueExtension
    {
        public static Queue<Transform> ToTransformQueue(this GameObject[] gameObjects)
        {
            Queue<Transform> transfromQueue = new();

            foreach (var obj in gameObjects)
            {
                transfromQueue.Enqueue(obj.transform);
            }

            return transfromQueue;
        }

        public static void AddChildrenToQueue(this Transform parent, Queue<Transform> queue)
        {
            foreach (Transform child in parent)
            {
                queue.Enqueue(child);
            }
        }
    }
}
