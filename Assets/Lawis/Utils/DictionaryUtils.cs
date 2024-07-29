using System.Collections.Generic;
using System.Linq;

namespace Assets.Lawis.Utils
{
    public static class DictionaryUtils
    {
        public static TKey GetRandomKeyFromDictionary<TKey, TValue>(Dictionary<TKey, TValue> dict)
        {
            return dict.ElementAt(UnityEngine.Random.Range(0, dict.Count)).Key;
        }
    }
}
