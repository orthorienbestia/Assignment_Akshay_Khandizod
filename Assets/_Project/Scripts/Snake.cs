using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts
{
    /// <summary>
    /// Handles Snake Movement and Collision.
    /// </summary>
    public class Snake : MonoBehaviour
    {
        [SerializeField] private GameObject bodyPartPrefab;
        [SerializeField] private float movementSpeed = 10f;
        [SerializeField] private float rotationSpeed = 10f;
        [SerializeField] private Transform navigatorArrow;
        
        private float _currentRotationValue;
        public void SetRotationValue(int value) => _currentRotationValue = value;
        private Transform _thisTransform;

        private const string WallTag = "Wall";
        private const string FoodTag = "Food";
        private const string BodyPartTag = "Snake Body";

        private bool _isGameEnded;

        private void Awake()
        {
            _thisTransform = transform;
            
            _bodyPartsPositionHistory.Add(_thisTransform.position);

            for (var index = 0; index < _bodyParts.Count; index++)
            {
                var bodyPart = _bodyParts[index];
                for (var i = 0; i < DistanceBetweenParts; i++)
                {
                    _bodyPartsPositionHistory.Add(_thisTransform.position - _thisTransform.forward * DistanceBetweenParts*index*20);    
                }
            }
        }

        private void FixedUpdate()
        {
            if (_isGameEnded)
            {
                return;
            }
            // Moving Forward
            var movementDirection = _thisTransform.rotation * Vector3.forward;
            _thisTransform.position += movementDirection * (movementSpeed * Time.deltaTime);
            
            // Rotation
            _thisTransform.Rotate(Vector3.up * (_currentRotationValue * rotationSpeed * Time.deltaTime));
            
            // Body Parts Movement

            _bodyPartsPositionHistory.Insert(0, _thisTransform.position);

            for (var i = 0; i < _bodyParts.Count; i++)
            {
                var position = _bodyPartsPositionHistory[
                    Mathf.Min(i * DistanceBetweenParts, _bodyPartsPositionHistory.Count-1)];
                _bodyParts[i].transform.position = position;
            }
            
            // Navigator arrow
            const float navigatorSpeed = 10f;
            if (SnakeGameManager.Instance.foodSpawningSystem.currentFoodTransform == null)
            {
                var rotation = Quaternion.LookRotation(transform.forward);
                navigatorArrow.rotation = Quaternion.Lerp(navigatorArrow.rotation, rotation, Time.deltaTime);
            }
            else
            {
                var foodPosition = SnakeGameManager.Instance.foodSpawningSystem.currentFoodTransform.position;
                var direction = foodPosition - transform.position;
                var rotation = Quaternion.LookRotation(direction);
                navigatorArrow.rotation = Quaternion.Lerp(navigatorArrow.rotation, rotation, navigatorSpeed * Time.deltaTime);
            }
        }

        private List<Vector3> _bodyPartsPositionHistory = new();
        [SerializeField]
        private List<GameObject> _bodyParts = new();
        
        private static int DistanceBetweenParts => 6;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(WallTag))
            {
                Debug.Log("Snake collided with wall");
                SnakeGameManager.Instance.EndGame();
                _isGameEnded = true;
            }
            else if (other.CompareTag(FoodTag))
            {
                Debug.Log("Food Eaten");
                var foodItem = other.gameObject.GetComponent<FoodItem>();
                foodItem.Eat();
                SnakeGameManager.Instance.onFoodEat.Invoke(foodItem.FoodParameters);
                
                // Snake Length increase
                var body = Instantiate(bodyPartPrefab);
                _bodyParts.Insert(_bodyParts.Count-1,body);
            }
            else if(other.CompareTag(BodyPartTag))
            {
                Debug.Log("Snake collided with body part");
                SnakeGameManager.Instance.EndGame();
                _isGameEnded = true;
            }
        }
    }
}
