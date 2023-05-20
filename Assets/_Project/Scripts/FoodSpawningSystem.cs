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

        private void Start()
        {
            SpawnRandomFoodItem();
        }

        [UsedImplicitly]
        public void SpawnRandomFoodItem()
        {
            var randomParameter = FoodConfigurationSystem.Instance.Data.GetRandomItem();

            var foodGameObject = Instantiate(foodPrefab);
            foodGameObject.GetComponent<FoodItem>().Initialize(randomParameter);
        }
    }
}