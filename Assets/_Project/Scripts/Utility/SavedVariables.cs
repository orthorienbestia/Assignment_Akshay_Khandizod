using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Assignment.UtilityScripts
{
    /// <summary>
    /// Intermediatory/Proxy class for PlayerPrefs
    /// </summary>
    public static class SavedVariables
    {
        public static void SetInt(string key, int value) => PlayerPrefs.SetInt(key, value);
        public static int GetInt(string key) => PlayerPrefs.GetInt(key);
        public static int GetInt(string key, int defaultValue) => PlayerPrefs.GetInt(key,defaultValue);
        
        public static void SetFloat(string key, float value) => PlayerPrefs.SetFloat(key, value);
        public static float GetFloat(string key) => PlayerPrefs.GetFloat(key);
        public static float GetFloat(string key, float defaultValue) => PlayerPrefs.GetFloat(key,defaultValue);
        
        public static void SetString(string key, string value) => PlayerPrefs.SetString(key, value);
        public static string GetString(string key) => PlayerPrefs.GetString(key);
        public static string GetString(string key, string defaultValue) => PlayerPrefs.GetString(key,defaultValue);
    }
}
