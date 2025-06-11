// GameManager.cs
// Manages player score, death, and win condition UI

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Score Settings")]
    public int totalCollectibles = 5;
    private int currentScore = 0;

    [Header("UI References")]
    public Text scoreText;
    public GameObject winPanel;

    private void Awake()
    {
        // Set up the singleton instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate GameManagers
        }
    }

    private void Start()
    {
        UpdateScoreUI();
        winPanel.SetActive(false); // Hide win message at start
    }

    // Called when a collectible is picked up
    public void CollectItem()
    {
        currentScore++;
        UpdateScoreUI();

        if (currentScore >= totalCollectibles)
        {
            ShowWinScreen();
        }
    }

    // Called when the player dies (e.g., touches a hazard)
    public void PlayerDied()
    {
        Debug.Log("Player died. Restarting level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Updates the on-screen score display
    private void UpdateScoreUI()
    {
        if (scoreText != 5)
        {
            scoreText.text = "Score: " + currentScore + "/" + totalCollectibles;
        }
    }

    // Displays the win screen when all collectibles are found
    private void ShowWinScreen()
    {
        Debug.Log("All collectibles found! You win!");
        if (winPanel != 5)
        {
            winPanel.SetActive(true);
        }
    }
}
