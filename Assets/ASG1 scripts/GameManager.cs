// GameManager.cs
// Handles player score, hazard deaths, UI updates, and win screen logic

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
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep GameManager across scenes
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
        AssignUIReferences();
        UpdateScoreUI();
    }

    // Called when a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScore = 0;  // Reset score every time scene reloads
        AssignUIReferences();
        UpdateScoreUI();

        if (winPanel != null)
            winPanel.SetActive(false);
    }

    private void AssignUIReferences()
    {
        if (scoreText == null)
            scoreText = GameObject.Find("ScoreText")?.GetComponent<TMP_Text>();

        if (winPanel == null)
            winPanel = GameObject.Find("WinPanel");

        if (scoreText == null)
            Debug.LogWarning(" ScoreText not found in scene.");

        if (winPanel == null)
            Debug.LogWarning(" WinPanel not found in scene.");
    }

    // Called by Collectible.cs
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore + "/" + totalCollectibles;
    }

    private void ShowWinScreen()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            Debug.Log(" All collectibles found! You win!");
        }
    }
}
