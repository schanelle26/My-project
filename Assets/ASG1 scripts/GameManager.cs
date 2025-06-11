using UnityEngine;
using UnityEngine.UI;
using TMPro; // For TextMeshPro
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Score Settings")]
    public int totalCollectibles = 5;
    private int currentScore = 0;

    [Header("UI References")]
    public TMP_Text scoreText;        // Assign TextMeshPro UI
    public GameObject winPanel;       // Panel shown when all items are collected

    private void Awake()
    {
        // Singleton setup
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: persists across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        UpdateScoreUI();

        if (winPanel != null)
            winPanel.SetActive(false); // Hide win panel initially
        else
            Debug.LogWarning("WinPanel not assigned in Inspector!");

        if (scoreText == null)
            Debug.LogWarning("ScoreText not assigned in Inspector!");
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

    public void PlayerDied(GameObject player, Transform respawnPoint)
    {
        // Move player to respawn point instead of reloading
        player.transform.position = respawnPoint.position;
        Debug.Log("Player died. Respawning at checkpoint.");
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
