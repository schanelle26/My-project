// GameManager.cs
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
        // Singleton setup (only one GameManager exists)
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: keep across scene reload
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnEnable()
    {
        // Listen for scene reload
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        ResetGame(); // Ensure score is 0 on first start
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Re-link UI objects after scene is reloaded
        scoreText = GameObject.Find("scoretext")?.GetComponent<TMP_Text>();
        winPanel = GameObject.Find("WinPanel");

        ResetGame(); // Reset score and UI
    }

    private void ResetGame()
    {
        currentScore = 0;
        UpdateScoreUI();

        if (winPanel != null)
            winPanel.SetActive(false);
        else
            Debug.LogWarning("WinPanel not assigned in scene!");

        if (scoreText == null)
            Debug.LogWarning("ScoreText not found! Make sure the Text has the right name.");
    }

    public void CollectItem()
    {
        currentScore++;
        UpdateScoreUI();

        if (currentScore >= totalCollectibles)
            ShowWinScreen();
    }

    public void PlayerDied()
    {
        Debug.Log("Player hit a hazard. Restarting scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Full scene reload
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
            Debug.Log("All collectibles found! You win!");
        }
    }
}
