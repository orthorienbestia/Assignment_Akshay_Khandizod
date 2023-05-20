using UnityEngine;

namespace _Project.Scripts
{
    public class FoodItem : MonoBehaviour
    {
        [SerializeField]
        private FoodParameters foodParameters;

        public void Initialize(FoodParameters parameters)
        {
            foodParameters = parameters;
            UpdateFoodItemColor();
        }

        private void UpdateFoodItemColor()
        {
            Debug.Log($"Updating Food Item Color {foodParameters.GetColorFromHex().ToString()}");
        }
    }
}