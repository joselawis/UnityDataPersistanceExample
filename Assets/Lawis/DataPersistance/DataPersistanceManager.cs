using Assets.Lawis.Singleton;
using System.IO;
using UnityEngine;

namespace Assets.Lawis.DataPersistance
{
    public abstract class DataPersistanceManager<T, V> : MonoBehaviourSingletonPersistent<V> where T : DataPersistable where V : Component
    {
        [SerializeField] protected string saveFileName = "saveFile";
        [SerializeField] protected T currentData;

        protected void DataToJson(T data)
        {
            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + $"/{saveFileName}.json", json);
        }

        protected T LoadDataFromJson()
        {
            string path = Application.persistentDataPath + $"/{saveFileName}.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                T data = JsonUtility.FromJson<T>(json);
                return data;
            }
            throw new FileNotFoundException($"Save file {saveFileName} not found.");
        }
    }
}
