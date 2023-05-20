using System;
using TMPro;
using UnityEngine;

namespace _Project.Scripts
{
    public class ScoringSystem : MonoBehaviour
    {
        [SerializeField] private TMP_Text currentScoreText;
        [SerializeField] private TMP_Text streakText;

        private int _currentScore = 0;
        private int _streakCounter = 0;
        private string _lastFoodColor = "";

        private void Awake()
        {
            streakText.SetText("");
        }

        public void FoodEaten(FoodParameters parameters)
        {
            if (_lastFoodColor == parameters.Color)
            {
                _streakCounter++;
                OnStreakIncreased();
            }
            else
            {
                _streakCounter = 1;
                _lastFoodColor = parameters.Color;
                OnStreakReset();
            }

            _currentScore += parameters.Points * _streakCounter;
            currentScoreText.SetText(_currentScore.ToString());
            Debug.Log($"Score Increased to {_currentScore.ToString()} !!");
        }

        private void OnStreakIncreased()
        {
            streakText.SetText($"x{_streakCounter.ToString()}");
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
