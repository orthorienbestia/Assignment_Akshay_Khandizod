using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
// ReSharper disable InconsistentNaming

namespace _Project.Scripts
{
    public class FoodConfigurationSystem : MonoBehaviour
    {
        [SerializeField] private string configJsonFileName = "FoodConfigurationData";
        [UsedImplicitly]
        public static FoodConfigurationSystem Instance { get; private set; }
        
        [UsedImplicitly]
        public List<FoodParameters> Data { get; private set; }
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
            Addressables.LoadAssetAsync<TextAsset>(configJsonFileName).Completed += OnConfigurationFileLoaded;
        }

        private void OnConfigurationFileLoaded(AsyncOperationHandle<TextAsset> operationHandle)
        {
            if (operationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                var textAsset = operationHandle.Result;
                Data = JsonUtility.FromJson<FoodData>(textAsset.ToString()).data;
                LogData();   
            }
            else
            {
                Debug.LogError("Failed to load JSON file: " + operationHandle.OperationException);
            }
        }
        
        private void LogData()
        {
            foreach (var foodParameters in Data)
            {
                Debug.Log($"Color: {foodParameters.Color} {foodParameters.GetColorFromHex().ToString()}, Points: {foodParameters.Points.ToString()}");
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