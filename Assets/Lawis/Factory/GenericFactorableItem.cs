using UnityEngine;

namespace Assets.Lawis.Factory
{
    public abstract class GenericFactorableItem : MonoBehaviour
    {
        [SerializeField] protected string id;

        public string Id { get => id; }
    }
}
