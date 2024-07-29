using System;

namespace Assets.Lawis.Utils
{
    public static class EnumUtils
    {
        public static T GetRandomEnumValue<T>() where T : Enum
        {
            Array enumValues = Enum.GetValues(typeof(T));
            int randomIndex = UnityEngine.Random.Range(0, enumValues.Length);
            return (T)enumValues.GetValue(randomIndex);
        }
    }
}
