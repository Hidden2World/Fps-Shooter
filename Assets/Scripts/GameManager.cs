using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Health;


public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject Wall;
    public TMP_Text EnemiesLeft;

    public HighScores m_HighScores;
    public Text m_MessageText;

    public GameObject m_HighScorePanel;
    public Text m_HighScoresText;

    public Button m_NewGameButton;
    public Button m_HighScoresButton;

    public GameObject[] targets;

    float gameTimer;

    enum GameState { Start, Playing, GameOver };
    GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        m_HighScorePanel.gameObject.SetActive(false);
        m_NewGameButton.gameObject.SetActive(false);
        m_HighScoresButton.gameObject.SetActive(false);
        m_MessageText.text = "";
        StartNewGame();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.Playing:
                gameTimer += Time.deltaTime;
                int seconds = Mathf.RoundToInt(gameTimer);

                bool gameOver = true;

                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i].activeSelf == true)
                    {
                        gameOver = false;
                    }
                }

                if (OneEnemy() == true)
                {
                    gameOver = true;
                }

                if (gameOver)
                {
                    gameState = GameState.GameOver;
                    Debug.Log("Game Has Ended");
                    Destroy(Wall);
                    m_MessageText.text = "Game Over";
                    m_NewGameButton.gameObject.SetActive(true);
                    m_HighScoresButton.gameObject.SetActive(true);
                }

                break;

            case GameState.Start:
                // You can add any initialization logic here if needed.
                gameState = GameState.Playing;
                break;

            case GameState.GameOver:
                // Handle game over state here if needed.
                break;
        }
    }

    private bool OneEnemy()
    {
        int Enemies = 0;
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].activeSelf == true)
            {
                int InitialEnemies = targets.Length;
                Enemies++;
                EnemiesLeft.text = $"Enemies: {Enemies}/{InitialEnemies}";
            }
        }
        return Enemies <= 1;
    }

    public void OnNewGame()
    {
        StartNewGame();
    }

    public void OnGameOver()
    {
        if (OneEnemy() == true)
        {

        m_HighScorePanel.gameObject.SetActive(true);
        m_HighScoresButton.gameObject.SetActive(true);
        m_NewGameButton.gameObject.SetActive(true);
        }
    }

    private void StartNewGame()
    {
        m_NewGameButton.gameObject.SetActive(false);
        m_HighScoresButton.gameObject.SetActive(false);
        m_HighScorePanel.SetActive(false);
        gameTimer = 0;
        gameState = GameState.Playing;
        m_MessageText.text = "";

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SetActive(true);
        }
    }

    public void OnHighScores()
    {
        m_MessageText.text = "";
        m_HighScoresButton.gameObject.SetActive(true);
        m_HighScorePanel.gameObject.SetActive(true);
        string text = "";
        for (int i = 0; i < m_HighScores.scores.Length; i++)
        {
            int seconds = m_HighScores.scores[i];
            text += string.Format("{0:D2}:{1:D2}\n",
            (seconds / 60), (seconds % 60));
        }
        m_HighScoresText.text = text;
    }
}
