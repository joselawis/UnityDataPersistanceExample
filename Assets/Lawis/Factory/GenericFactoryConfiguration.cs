using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Lawis.Factory
{
    public abstract class GenericFactoryConfiguration<T> : ScriptableObject where T : GenericFactorableItem
    {
        [SerializeField] private T[] itemPrefabs;
        public Dictionary<string, T> ItemDictionary { get; private set; }

        private void Awake()
        {
            ItemDictionary = new Dictionary<string, T>();
            foreach (var item in itemPrefabs)
            {
                ItemDictionary.Add(item.Id, item);
            }
        }

        public virtual T GetItemPrefabByType(string id)
        {
            if (!ItemDictionary.TryGetValue(id, out var item))
            {
                throw new ArgumentOutOfRangeException($"Id not valid: {id}");
            }
            return item;
        }

        public virtual T GetRandomPrefab()
        {
            return ItemDictionary.ElementAt(UnityEngine.Random.Range(0, ItemDictionary.Count)).Value;
        }
    }
}
