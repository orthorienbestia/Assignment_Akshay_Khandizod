using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace _Project.Scripts.GameScene
{
    public class FoodConfigurationInitializer : MonoBehaviour
    {
        
        private void Awake()
        {
            Addressables.LoadAssetAsync<TextAsset>("FoodConfigurationData").Completed += OnConfigurationFileLoaded;
        }

        private static void OnConfigurationFileLoaded(AsyncOperationHandle<TextAsset> operationHandle)
        {
            if (operationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                var textAsset = operationHandle.Result;
                FoodConfigurationData.InitializeWithJson(textAsset.ToString());
                FoodConfigurationData.LogData();   
            }
            else
            {
                Debug.LogError("Failed to load JSON file: " + operationHandle.OperationException);
            }
        }
    }
}