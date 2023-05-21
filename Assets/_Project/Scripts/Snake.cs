using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts
{
    public class Snake : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 10f;
        [SerializeField] private float rotationSpeed = 10f;
        private float _currentRotationValue;
        public void SetRotationValue(int value) => _currentRotationValue = value;
        private Transform _thisTransform;

        private const string WallTag = "Wall";
        private const string FoodTag = "Food";

        private void Awake()
        {
            _thisTransform = transform;
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
            transform.Rotate(Vector3.up * (_currentRotationValue * rotationSpeed * Time.deltaTime));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(WallTag))
            {
                Debug.Log("Collided with wall");
                SceneManager.LoadScene(0);
            }
            else if (other.CompareTag("Food"))
            {
                Debug.Log("Food Eaten");
            }
        }
    }
}
