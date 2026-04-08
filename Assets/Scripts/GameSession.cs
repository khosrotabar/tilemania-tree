using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] float delayOfRestartPlayer = 1f;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake()
    {
        // Create our singleton
        int numGameSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    private void TakeLife()
    {
        playerLives--;
        StartCoroutine(ReloadSceneWithDelay(delayOfRestartPlayer));
        livesText.text = playerLives.ToString();
    }

    IEnumerator ReloadSceneWithDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void ResetGameSession()
    {
        StartCoroutine(RestartSceneWithDelay(delayOfRestartPlayer));
    }

    IEnumerator RestartSceneWithDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        SceneManager.LoadScene(0);
        Destroy(gameObject);
        FindAnyObjectByType<ScenePersist>().ResetScenePersist();
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    void Update()
    {
        
    }
}
