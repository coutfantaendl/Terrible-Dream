using UnityEngine;

namespace Scripts.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField, Range(0.5f, 2)] private float _speed;
        [SerializeField] private float _gravityValue = -9.81f;

        private Vector3 _playerVelocity;

        private CharacterController _characterController;
        private PlayerView _playerView;
        private InputManager _inputManager;
        private Transform _cameraTransform;

        private bool _isMoving;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _playerView = GetComponent<PlayerView>();

            _cameraTransform = Camera.main.transform;
            _inputManager = InputManager.Instance;
        }

        private void Update()
        {            
            Move();
            HandleWslkingSound();
        }

        private void Move()
        {
            Vector2 movement = _inputManager.GetPlayerMovement();
            Vector3 move = new Vector3(movement.x, 0f, movement.y);

            move = _cameraTransform.forward * move.z + _cameraTransform.right * move.x;
            move.y = 0f;

            _characterController.Move(move * _speed * Time.deltaTime);

            _playerVelocity.y += _gravityValue * Time.deltaTime;
            _characterController.Move(_playerVelocity * Time.deltaTime);

            _isMoving = move.magnitude > 0.1f;
        }

        private void HandleWslkingSound()
        {
            if(_isMoving )
            {
                _playerView.PlayWalkingSound();
            }
            else
            {
                _playerView.StopWalkingSound();
            }
        }
    }
}
