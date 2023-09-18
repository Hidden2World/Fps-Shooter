using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Health;


public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject Wall;
    public TMP_Text EnemiesLeft;
    




    public GameObject[] targets;

    float gameTimer;

    enum GameState { Start, Playing, GameOver };
    GameState gameState;


    // Start is called before the first frame update
    void Start()
    {
       
        gameState = GameState.Start;
        


    }



    // Update is called once per frame
    void Update()
    {
        
        switch (gameState)
        {
            case GameState.Start:
                gameTimer = 0;
                gameState = GameState.Playing;

                break;


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
                }


                break;


            case GameState.GameOver:

                Debug.Log("Game Has Ended");
                Destroy(Wall);
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
}