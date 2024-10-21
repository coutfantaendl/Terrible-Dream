public interface IPause
{
    void PauseGame();
    void ResumGame();

    bool IsPaused { get; }
}
