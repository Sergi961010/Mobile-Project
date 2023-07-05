using System;

namespace TheCreators.Utilities
{
    public static class Utility
    {
        public static int RandomValue(int min, int max)
        {
            int random = UnityEngine.Random.Range(min, max);
            return random;
        }
	    public static T RandomEnumValue<T>()
        {
            var values = Enum.GetValues(typeof(T));
            int random = UnityEngine.Random.Range(0, values.Length);
            return (T)values.GetValue(random);
        }
    }
}