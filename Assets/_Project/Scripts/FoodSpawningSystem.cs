using System;
using System.Collections;
using Assignment.UtilityScripts;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts
{
    public class FoodSpawningSystem : MonoBehaviour
    {
        [SerializeField]
        private string foodPrefabName;
        [SerializeField]
        private GameObject foodPrefab;

        [SerializeField] private float spawnAreaSide;
        
        private int _counter;

        private void Start()
        {
            StartCoroutine(_SpawnFoodContinuously());
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

        IEnumerator _SpawnFoodContinuously()
        {
            while (true)
            {
                SpawnRandomFoodItem();
                yield return new WaitForSeconds(1);
            }
        }
    }
}