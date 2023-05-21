using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace _Project.Scripts
{
    public class SnakeGameManager : MonoBehaviour
    {
        [SerializeField] private GameObject thirdPersonCamera;
        [SerializeField] private GameObject birdViewCamera;

        private bool _isThirdPersonCameraActive;
        
        public static SnakeGameManager Instance { get; private set; }

        public UnityEvent onGameEnded;

        public UnityEvent<FoodParameters> onFoodEat;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            
            ChangeCameraView();
        }

        [UsedImplicitly]
        public void ChangeCameraView()
        {
            _isThirdPersonCameraActive = !_isThirdPersonCameraActive;
            thirdPersonCamera.SetActive(_isThirdPersonCameraActive);
            birdViewCamera.SetActive(!_isThirdPersonCameraActive);
        }

        public void EndGame()
        {
            onGameEnded.Invoke();
            SceneManager.LoadScene(0);
        }
    }
}
