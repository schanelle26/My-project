/*
* Author: Schanelle Jackson
* Date: 2025-06-13
* Description: Handles player score, hazard death logic, UI updates, and winpanel screen display using .
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Manages game state including scoring, hazard deaths, UI updates, and win conditions.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of the GameManager.
    /// </summary>
    public static GameManager instance;

    [Header("Score Settings")]
    /// <summary>
    /// Total number of collectibles required to win.
    /// </summary>
    public int totalCollectibles = 5;

    /// <summary>
    /// Current number of collectibles collected.
    /// </summary>
    private int currentScore = 0;

    [Header("UI References")]
    /// <summary>
    /// Reference to the score text UI element.
    /// </summary>
    public TMP_Text scoreText;

    /// <summary>
    /// Reference to the win screen panel UI.
    /// </summary>
    public GameObject winPanel;

    /// <summary>
    /// Called when the object is initialized.
    /// Sets up the Singleton pattern.
    /// </summary>
    private void Awake()
    {
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

    /// <summary>
    /// Subscribes to scene loaded event.
    /// </summary>
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// Unsubscribes from scene loaded event.
    /// </summary>
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    /// <summary>
    /// Called at the start of the first scene. Assigns UI references and updates score.
    /// </summary>
    private void Start()
    {
        AssignUIReferences();
        UpdateScoreUI();
    }

    /// <summary>
    /// Called when a new scene is loaded. Resets score and UI.
    /// </summary>
    /// <param name="scene">The loaded scene.</param>
    /// <param name="mode">The load mode.</param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScore = 0;
        AssignUIReferences();
        UpdateScoreUI();

        if (winPanel != null)
            winPanel.SetActive(false);
    }

    /// <summary>
    /// Finds and assigns references to UI elements in the scene.
    /// </summary>
    private void AssignUIReferences()
    {
        if (scoreText == null)
            scoreText = GameObject.Find("ScoreText")?.GetComponent<TMP_Text>();

        if (winPanel == null)
            winPanel = GameObject.Find("WinPanel");

        if (scoreText == null)
            Debug.LogWarning("ScoreText not found in scene.");

        if (winPanel == null)
            Debug.LogWarning("WinPanel not found in scene.");
    }

    /// <summary>
    /// Called by collectibles to update score and check for win condition.
    /// </summary>
    public void CollectItem()
    {
        currentScore++;
        UpdateScoreUI();

        if (currentScore >= totalCollectibles)
        {
            ShowWinScreen();
        }
    }

    /// <summary>
    /// Called when the player dies from a hazard. Reloads the current scene.
    /// </summary>
    public void PlayerDied()
    {
        Debug.Log("Player hit hazard. Restarting level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Updates the UI text to show the current score.
    /// </summary>
    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore + "/" + totalCollectibles;
    }

    /// <summary>
    /// Displays the win screen UI when all collectibles are found.
    /// </summary>
    private void ShowWinScreen()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            Debug.Log("All collectibles found! You win!");
        }
    }
}
