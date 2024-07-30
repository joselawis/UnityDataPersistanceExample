using Newtonsoft.Json;

namespace Assets.Lawis.Utils
{
    public static class JsonHelper
    {
        public static T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string ToJson<T>(T o)
        {
            return JsonConvert.SerializeObject(o);
        }
    }
}