using Scripts.Player;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;
    private PlayerController _playerController;
    private CinemachinePOVExtension _extension;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();

        FindObjectOfType<PlayerController>().Initialize(this);
        FindObjectOfType<CinemachinePOVExtension>().Initialize(this);

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
