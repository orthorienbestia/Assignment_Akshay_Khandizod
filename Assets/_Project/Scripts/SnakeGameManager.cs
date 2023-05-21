using System;
using JetBrains.Annotations;
using UnityEngine;

namespace _Project.Scripts
{
    public class SnakeGameManager : MonoBehaviour
    {
        [SerializeField] private GameObject thirdPersonCamera;
        [SerializeField] private GameObject birdViewCamera;

        private bool _isThirdPersonCameraActive;

        private void Awake()
        {
            ChangeCameraView();
        }

        [UsedImplicitly]
        public void ChangeCameraView()
        {
            _isThirdPersonCameraActive = !_isThirdPersonCameraActive;
            thirdPersonCamera.SetActive(_isThirdPersonCameraActive);
            birdViewCamera.SetActive(!_isThirdPersonCameraActive);
        }
    }
}
