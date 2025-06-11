using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

    private void Start()
    {
        UpdateScoreUI();

        if (winPanel != null)
            winPanel.SetActive(false);
        else
            Debug.LogWarning("WinPanel not assigned!");

        if (scoreText == null)
            Debug.LogWarning("ScoreText not assigned!");
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
        player.transform.position = respawnPoint.position;
        Debug.Log("Player died. Respawned.");
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
