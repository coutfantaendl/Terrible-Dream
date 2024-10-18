using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;

    public static InputManager Instance { get { return _instance; } }

    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;

        _playerInputActions = new PlayerInputActions();
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
}
