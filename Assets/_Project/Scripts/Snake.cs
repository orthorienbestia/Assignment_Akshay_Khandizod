using UnityEngine;

namespace _Project.Scripts
{
    public class Snake : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 10f;
        [SerializeField] private float rotationSpeed = 10f;
        private float _currentRotationValue;
        private void Update()
        {
            // Moving Forward
            Vector3 movementDirection = transform.rotation * Vector3.forward;
            transform.position += movementDirection * (movementSpeed * Time.deltaTime);
            
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
            //_currentRotationValue = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * (_currentRotationValue * rotationSpeed * Time.deltaTime));
        }

        // public void SetRotationValue(int value) => _currentRotationValue = value;
    }
}
