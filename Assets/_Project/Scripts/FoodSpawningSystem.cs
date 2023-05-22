using Assignment.UtilityScripts;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts
{
    /// <summary>
    /// Spawns random food at random position.
    /// </summary>
    public class FoodSpawningSystem : MonoBehaviour
    {
        [SerializeField]
        private GameObject foodPrefab;

        [SerializeField] private float spawnAreaSide;
        
        private int _counter;

        private void Start()
        {
            SpawnRandomFoodItem();
            SnakeGameManager.Instance.onFoodEat.AddListener(_ => SpawnRandomFoodItem());
        }

        [UsedImplicitly]
        [ContextMenu("Spawn Food Item")]
        public void SpawnRandomFoodItem()
        {
            _counter++;
            
            var randomParameter = FoodConfigurationSystem.Instance.Data.GetRandomItem();

            var foodGameObject = Instantiate(foodPrefab, transform);
            foodGameObject.name = $"Food Item {_counter.ToString()}";
            foodGameObject.transform.position = new Vector3(Random.Range(-spawnAreaSide/2,spawnAreaSide/2),1,Random.Range(-spawnAreaSide/2,spawnAreaSide/2));
            foodGameObject.GetComponent<FoodItem>().Initialize(randomParameter);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawCube(transform.position, new Vector3(spawnAreaSide, 0, spawnAreaSide));
        }
    }
}