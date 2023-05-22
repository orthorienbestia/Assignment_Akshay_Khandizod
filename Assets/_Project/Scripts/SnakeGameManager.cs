using Assignment.UtilityScripts;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace _Project.Scripts
{
    public class SnakeGameManager : MonoBehaviour
    {
        [SerializeField] private ScoringSystem scoringSystem;
        [SerializeField] private GameObject thirdPersonCamera;
        [SerializeField] private GameObject birdViewCamera;
        [SerializeField] private Animator gameOverAnimator;
        [SerializeField] private GameObject gameOverGO;
        [SerializeField] private TMP_Text gameOverCurrentScoreTxt;
        [SerializeField] private TMP_Text gameOverHighScoreTxt;
        
        public UnityEvent onGameEnded;
        public UnityEvent<FoodParameters> onFoodEat;
        
        private bool _isThirdPersonCameraActive;
        public static SnakeGameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            
            ChangeCameraView();
            gameOverGO.SetActive(false);
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
            if(scoringSystem.CurrentScore > SavedVariables.GetInt("high_score"))
            {
                SavedVariables.SetInt("high_score", scoringSystem.CurrentScore);
            }
            
            onGameEnded.Invoke();
            gameOverCurrentScoreTxt.SetText($"Current Score: {scoringSystem.CurrentScore.ToString()}");
            gameOverHighScoreTxt.SetText($"High Score: {SavedVariables.GetInt("high_score").ToString()}");
            gameOverGO.SetActive(true);
            gameOverAnimator.Play("GameOverPanel");
        }

        public void LoadHomeScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}
