using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event Action GameOverEvent;
    public int score;
    public TextMeshProUGUI scoreText;
    private bool isGameOver;
    private bool resetScoreOnNextLoad;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log($"Score increased by {amount}. Total: {score}");
        UpdateScoreText();
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        resetScoreOnNextLoad = true;
        Debug.Log("Game Over! Reloading scene in 2 seconds.");
        GameOverEvent?.Invoke();
        Invoke(nameof(ReloadScene), 2f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scoreText != null && scoreText.gameObject.scene != scene)
        {
            scoreText = null;
        }

        if (scoreText == null)
        {
            GameObject scoreTextObject = GameObject.FindWithTag("ScoreText");
            if (scoreTextObject != null)
            {
                scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
            }
        }

        if (scoreText == null)
        {
            TextMeshProUGUI[] candidates = FindObjectsOfType<TextMeshProUGUI>(true);
            foreach (TextMeshProUGUI candidate in candidates)
            {
                if (candidate != null && candidate.name.ToLowerInvariant().Contains("score"))
                {
                    scoreText = candidate;
                    break;
                }
            }
        }

        if (scoreText == null)
        {
            Debug.LogWarning("ScoreText not found in scene. Score UI will not update.");
        }

        isGameOver = false;
        if (resetScoreOnNextLoad || scene.name.Equals("MainMenu", StringComparison.OrdinalIgnoreCase))
        {
            ResetScore();
            resetScoreOnNextLoad = false;
        }
        UpdateScoreText();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }
}
