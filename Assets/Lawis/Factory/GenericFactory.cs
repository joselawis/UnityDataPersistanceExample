using UnityEngine;

namespace Assets.Lawis.Factory
{
    public abstract class GenericFactory<T> where T : GenericFactorableItem
    {
        protected GenericFactoryConfiguration<T> itemConfiguration;

        public GenericFactory(GenericFactoryConfiguration<T> itemConfiguration)
        {
            this.itemConfiguration = itemConfiguration;
        }

        public virtual T Create(string id, Vector3 position, Quaternion rotation) => Object.Instantiate(itemConfiguration.GetItemPrefabByType(id), position, rotation);

        public virtual T CreateRandom(Vector3 position, Quaternion rotation) => Object.Instantiate(itemConfiguration.GetRandomPrefab(), position, rotation);
    }
}
