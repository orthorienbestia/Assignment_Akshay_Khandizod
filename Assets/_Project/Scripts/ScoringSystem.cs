using TMPro;
using UnityEngine;

namespace _Project.Scripts
{
    /// <summary>
    /// Handles current and high score.
    /// Increases current score using food parameter.
    /// </summary>
    public class ScoringSystem : MonoBehaviour
    {
        [SerializeField] private TMP_Text currentScoreText;
        [SerializeField] private TMP_Text streakText;

        private int _currentScore = 0;
        private int _streakCounter = 0;
        private string _lastFoodColor = "";
        private int _foodEatenCounter = 0;

        public int CurrentScore => _currentScore;

        private void Awake()
        {
            streakText.SetText("");
            currentScoreText.SetText(_currentScore.ToString());
            SnakeGameManager.Instance.onFoodEat.AddListener(OnFoodEat);
        }

        private void OnFoodEat(FoodParameters parameters)
        {
            if (_foodEatenCounter == 0 || _lastFoodColor == parameters.Color)
            {
                _streakCounter++;
                OnStreakIncreased();
            }
            else
            {
                _streakCounter = 1;
                OnStreakReset();
            }
            
            _lastFoodColor = parameters.Color;
            _currentScore += parameters.Points * _streakCounter;
            currentScoreText.SetText(_currentScore.ToString());
            Debug.Log($"Score Increased to {_currentScore.ToString()} !!");

            _foodEatenCounter++;
        }

        private void OnStreakIncreased()
        {
            streakText.SetText($"Streak: x{_streakCounter.ToString()}");
            Debug.Log($"Streak Increased to {_streakCounter.ToString()} !!");
        }

        private void OnStreakReset()
        {
            if (_currentScore == 0) return;
            streakText.SetText($"Streak: x{_streakCounter.ToString()}");
            Debug.Log($"Streak Reset to {_streakCounter.ToString()} !!");
        }
    }
}
