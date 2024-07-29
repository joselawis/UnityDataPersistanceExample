using System.Linq;
using UnityEngine;

namespace Assets.Lawis.Utils
{
    public static class MonoBehaviourUtils
    {
        public static bool HasComponent<T>(this GameObject go) where T : Component
        {
            return go.GetComponentsInChildren<T>().FirstOrDefault() != null;
        }
    }
}

