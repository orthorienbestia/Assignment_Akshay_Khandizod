using Assignment.UtilityScripts;
using JetBrains.Annotations;
using UnityEngine;

namespace _Project.Scripts
{
    public class FoodSpawningSystem : MonoBehaviour
    {
        [SerializeField]
        private string foodPrefabName;
        [SerializeField]
        private GameObject foodPrefab;

        private int _counter;

        private void Start()
        {
            // SpawnRandomFoodItem();
        }

        [UsedImplicitly]
        [ContextMenu("Spawn Food Item")]
        public void SpawnRandomFoodItem()
        {
            _counter++;
            
            var randomParameter = FoodConfigurationSystem.Instance.Data.GetRandomItem();

            var foodGameObject = Instantiate(foodPrefab, transform);
            foodGameObject.name = $"Food Item {_counter.ToString()}";
            
            foodGameObject.GetComponent<FoodItem>().Initialize(randomParameter);
        }
    }
}