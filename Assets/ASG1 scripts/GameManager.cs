// GameManager.cs
// Handles score, collectible tracking, win message, and scene reloading

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Score Settings")]
    public int totalCollectibles = 5;
    private int currentScore = 0;

    [Header("UI References")]
    public TMP_Text scoreText;
    public GameObject winPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        SetupUI();
        UpdateScoreUI();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // After scene reload, find the UI again
        SetupUI();
        UpdateScoreUI();
    }

    void SetupUI()
    {
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TMP_Text>();
        winPanel = GameObject.Find("WinPanel");

        if (scoreText == null)
            Debug.LogWarning("ScoreText not assigned or found in scene!");

        if (winPanel != null)
            winPanel.SetActive(false);
        else
            Debug.LogWarning("WinPanel not assigned or found in scene!");
    }

    public void CollectItem()
    {
        currentScore++;
        UpdateScoreUI();

        if (currentScore >= totalCollectibles)
        {
            ShowWinScreen();
        }
    }

    public void PlayerDied()
    {
        Debug.Log("Player hit hazard. Restarting level...");

        // Reset score to 0 on death
        currentScore = 0;

        // Reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"Score: {currentScore}/{totalCollectibles}";
    }

    private void ShowWinScreen()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            Debug.Log("You win!");
        }
    }
}
