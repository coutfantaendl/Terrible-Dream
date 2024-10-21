using Scripts.Lighting;
using Scripts.Player;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();

        FindObjectOfType<PlayerController>().Initialize(this);
        FindObjectOfType<CinemachinePOVExtension>().Initialize(this);
        FindObjectOfType<FlashlightController>().Initialize(this);
        FindObjectOfType<PauseManager>().Initialize(this);

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        _playerInputActions.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return _playerInputActions.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return _playerInputActions.Player.Look.ReadValue<Vector2>();
    }

    public bool IsFlashlightTogglePressed()
    {
        return _playerInputActions.Player.Flashlight.triggered;
    }

    public bool Pause()
    {
        return _playerInputActions.Player.IsPausePressed.triggered;
    }
}


