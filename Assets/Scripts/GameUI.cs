using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("HUD")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI weaponText;
    public TextMeshProUGUI healthText;
    public Slider healthBar;

    [Header("End Screen")]
    public GameObject endScreenPanel;
    public TextMeshProUGUI finalScoreText;
    public Button restartButton;
    public Button mainMenuButton;

    [Header("Crosshair")]
    public GameObject crosshair;

    WeaponSystem weaponSystem;
    public Health playerHealth;

    void Start()
    {
        endScreenPanel.SetActive(false);

        GameManager gm = GameManager.Instance;
        gm.OnScoreChanged += UpdateScore;
        gm.OnTimeChanged += UpdateTimer;
        gm.OnGameEnd += ShowEndScreen;

        restartButton.onClick.AddListener(() => gm.RestartGame());
        mainMenuButton.onClick.AddListener(() => gm.LoadMainMenu());

        weaponSystem = FindFirstObjectByType<WeaponSystem>();

        UpdateScore(0);
        UpdateTimer(gm.gameDuration);
    }

    void Update()
    {
        if (weaponSystem != null && weaponText != null)
            weaponText.text = weaponSystem.CurrentBulletType.ToString();

        if (playerHealth != null && healthBar != null && healthText != null)
            UpdateHealth();
    }

    void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateHealth()
    {
        healthText.text = $"{playerHealth.CurrentHealth}";
        healthBar.value = playerHealth.CurrentHealth;
    }

    void UpdateTimer(float time)
    {
        int seconds = Mathf.CeilToInt(time);
        timerText.text = seconds.ToString();
    }

    void ShowEndScreen()
    {
        endScreenPanel.SetActive(true);
        finalScoreText.text = "Final Score\n" + GameManager.Instance.Score;
        if (crosshair != null) crosshair.SetActive(false);
    }
}
