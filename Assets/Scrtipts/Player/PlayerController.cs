using Scripts.Player.PlayerView;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField, Range(1, 3)] private float _speed;

    private CharacterController _characterController;
    private PlayerView _playerView;

    private Vector2 _moveInput;
    private Vector3 _moveDirection;

    private PlayerInputActions _playerIputActions;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerView = GetComponent<PlayerView>();
        _playerIputActions = new PlayerInputActions();
    }

    private void Update()
    {
        if (_moveInput == Vector2.zero)
        {       
            _playerView.StopWalkingSound();
            return;
        }

        Move();
  
        _playerView.PlayWalkingSound();
    }

    private void OnEnable()
    {
        _playerIputActions.Player.Move.performed += OnMovePerforned;
        _playerIputActions.Player.Move.canceled += OnMoveCanceled;

        _playerIputActions.Enable();
    }

    private void OnDisable()
    {
        _playerIputActions.Player.Move.performed -= OnMovePerforned;
        _playerIputActions.Player.Move.canceled -= OnMoveCanceled;

        _playerIputActions.Disable();
    }

    private void Move()
    {
        _moveDirection = new Vector3(_moveInput.x, 0, _moveInput.y);

        _characterController.Move(_moveDirection * _speed * Time.deltaTime);
    }

    private void OnMovePerforned(InputAction.CallbackContext contex)
    {
        _moveInput = contex.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext contex)
    {
        _moveInput = Vector2.zero;
    }
}
