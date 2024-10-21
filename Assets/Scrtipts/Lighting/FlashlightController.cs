using System;
using TMPro;
using UnityEngine;

namespace Scripts.Lighting
{
    public class FlashlightController : MonoBehaviour
    {
        [Header("FlashLight Settings")]
        [SerializeField] private Light _flashlight;
        [SerializeField] private TextMeshProUGUI _interactionUI;

        private bool _isFlashlightOn = false;
        private InputManager _inputManager;
  
        private void Awake()
        {
            if(_flashlight == null)
            {
                enabled = false;
                throw new ArgumentNullException(paramName: nameof(gameObject.name), message: "Light reference is missing");             
            }

            _flashlight.enabled = _isFlashlightOn;
        }

        public void Initialize(InputManager inputManager)
        {
            _inputManager = inputManager;
        }

        private void Update()
        {
            if(_inputManager != null && _inputManager.IsFlashlightTogglePressed())
            {
                ToggleFlashlight();
                _interactionUI.enabled = false;
            }
        }

        private void ToggleFlashlight()
        {
            _isFlashlightOn = !_isFlashlightOn;
            _flashlight.enabled = _isFlashlightOn;
        }
    }
}
