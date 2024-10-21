using UnityEngine;

public class PauseManager : MonoBehaviour, IPause
{
    [SerializeField] private GameObject _pauseMenuUI;

    private InputManager _inputManager;

    public bool IsPaused { get; private set; }

    public void Initialize(InputManager inputManager)
    {
        _inputManager = inputManager;
    }

    private void Awake()
    {
        _pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        HandlePauseInput();
    }

    private void HandlePauseInput()
    {
        if (!_inputManager.Pause())
            return;

        if (IsPaused)
            ResumGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        ToggleCursor(true);
    }

    public void ResumGame()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        ToggleCursor(false);
    }

    private void ToggleCursor(bool showCursor)
    {
        Cursor.lockState = showCursor ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = showCursor;
    }
}
