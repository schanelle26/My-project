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
        UpdateScoreUI();

        if (winPanel != null)
            winPanel.SetActive(false);

        if (scoreText == null)
            Debug.LogWarning("ScoreText not assigned in inspector!");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reassign UI references after scene reload
        scoreText = GameObject.Find("scoretext")?.GetComponent<TMP_Text>();
        winPanel = GameObject.Find("WinPanel");

        UpdateScoreUI();
        if (winPanel != null)
            winPanel.SetActive(false);
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
            Debug.Log("You win!");
        }
    }
}
