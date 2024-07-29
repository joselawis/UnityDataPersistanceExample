using Assets.Lawis.Singleton;
using UnityEditor;
using UnityEngine;

namespace Assets.Lawis.UI
{
    [DefaultExecutionOrder(1000)]
    public abstract class UIManager<V> : MonoBehaviourSingleton<V> where V : Component
    {
        public virtual void Exit()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}
