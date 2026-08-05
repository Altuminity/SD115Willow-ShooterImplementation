using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Wwise States")]
    public AK.Wwise.Event setGameState;
    public AK.Wwise.Event setMenuState;

    [Header("Game Settings")]
    public float gameDuration = 60f;

    public float TimeRemaining { get; private set; }
    public int Score { get; private set; }
    public bool IsGameActive { get; private set; }

    public event System.Action<int> OnScoreChanged;
    public event System.Action<float> OnTimeChanged;
    public event System.Action OnGameEnd;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (!IsGameActive) return;

        TimeRemaining -= Time.deltaTime;
        OnTimeChanged?.Invoke(TimeRemaining);

        if (TimeRemaining <= 0f)
        {
            TimeRemaining = 0f;
            EndGame();
        }
    }

    public void StartGame()
    {
        setGameState.Post(gameObject);
        Score = 0;
        TimeRemaining = gameDuration;
        IsGameActive = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void AddScore(int points)
    {
        if (!IsGameActive) return;
        Score += points;
        OnScoreChanged?.Invoke(Score);
    }

    public void EndGame()
    {
        setMenuState.Post(gameObject);
        IsGameActive = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        OnGameEnd?.Invoke();
    }

    public void RestartGame()
    {
        setGameState.Post(gameObject);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
