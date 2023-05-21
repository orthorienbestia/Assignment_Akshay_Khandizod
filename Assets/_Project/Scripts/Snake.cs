using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts
{
    public class Snake : MonoBehaviour
    {
        [SerializeField] private GameObject bodyPartPrefab;
        [SerializeField] private float movementSpeed = 10f;
        [SerializeField] private float rotationSpeed = 10f;
        
        private float _currentRotationValue;
        public void SetRotationValue(int value) => _currentRotationValue = value;
        private Transform _thisTransform;

        private const string WallTag = "Wall";
        private const string FoodTag = "Food";
        private const string BodyPartTag = "Snake Body";

        private void Awake()
        {
            _thisTransform = transform;
            
            _bodyPartsPositionHistory.Add(_thisTransform.position);

            for (var index = 0; index < _bodyParts.Count; index++)
            {
                var bodyPart = _bodyParts[index];
                _bodyPartsPositionHistory.Add(_thisTransform.position - _thisTransform.forward * DistanceBetweenParts*index);
            }
        }

        private void Update()
        {
            // Moving Forward
            var movementDirection = _thisTransform.rotation * Vector3.forward;
            _thisTransform.position += movementDirection * (movementSpeed * Time.deltaTime);
            
            // Rotation
#if UNITY_EDITOR
            if (!Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    _currentRotationValue = -1;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    _currentRotationValue = 1;
                }
                else
                {
                    _currentRotationValue = 0;
                }
            }
#endif
            _thisTransform.Rotate(Vector3.up * (_currentRotationValue * rotationSpeed * Time.deltaTime));
            
            // Body Parts Movement

            _bodyPartsPositionHistory.Insert(0, _thisTransform.position);

            for (var i = 0; i < _bodyParts.Count; i++)
            {
                Debug.Log("^^^^^ " + Mathf.Min(i * DistanceBetweenParts, _bodyPartsPositionHistory.Count));
                var position = _bodyPartsPositionHistory[
                    Mathf.Min(i * DistanceBetweenParts, _bodyPartsPositionHistory.Count-1)];
                _bodyParts[i].transform.position = position;
            }
        }

        private List<Vector3> _bodyPartsPositionHistory = new();
        [SerializeField]
        private List<GameObject> _bodyParts = new();
        
        private const int DistanceBetweenParts = 25;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(WallTag))
            {
                Debug.Log("Snake collided with wall");
                SnakeGameManager.Instance.EndGame();
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
            }
        }
    }
}
