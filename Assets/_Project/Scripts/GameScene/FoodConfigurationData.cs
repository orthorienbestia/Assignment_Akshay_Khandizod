using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace _Project.Scripts.GameScene
{
    public static class FoodConfigurationData
    {
        [UsedImplicitly]
        public static List<FoodParameters> Data { get; private set; }

        public static List<FoodParameters> InitializeWithJson(string jsonString)
        {
            Data = JsonUtility.FromJson<FoodData>(jsonString).data;
            return Data;
        }

        public static void LogData()
        {
            foreach (var foodParameters in Data)
            {
                Debug.Log($"Color: {foodParameters.Color} / {foodParameters.GetColorFromHex().ToString()}, Points: {foodParameters.Points}");
            }
        }
    }

    [System.Serializable]
    public class FoodData
    {
        public List<FoodParameters> data;
    }

    [System.Serializable]
    public class FoodParameters
    {
        public string Color;
        public int Points;

        public Color GetColorFromHex()
        {
            if (ColorUtility.TryParseHtmlString(Color, out var color))
            {
                return color;
            }

            Debug.LogError("Invalid color string!");
            return new Color(1, 1, 1, 1);
        }
    }
}