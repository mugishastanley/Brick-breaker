using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ball initialBall;
    public Ball ballPrefab;
    public Block blockprefab;

    public Paddle paddle;
    public static Boolean gamestarted;
    public static Boolean startGame;

    public Text EndScreen;
    
    public int _rows = 2;
    public int _cols = 2;
    int countstart = 0;
    private int countblocks;

    public Text redScore;
    public Text greenScore;
    public Text blueScore;

    bool gameIsPaused = false;
 
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        
        InitializeBall();
        initializeblocks();
    }

    // Update is called once per frame
    void Update()
    {
        PreStartGame();
        YouWin();
        Score();
        Reset();

    }

    void YouWin() {
        if (FindObjectOfType<Ball>().lost)
        {
            EndScreen.text = " You Lose !! Press R to Reset";
            gameIsPaused = true;
            PauseGame();
        }
            

        if (Input.GetKeyDown(KeyCode.Escape))
        {
           gameIsPaused = !gameIsPaused;
            PauseGame();
        }

        int numblocks = FindObjectOfType<Ball>().countBlocksDestroyed;
        if (countblocks == numblocks) {
            EndScreen.text = "YouWin!! Advance to level 2 ";
        }
    }

    void Score() {
        redScore.text ="Red:"+ (FindObjectOfType<Ball>().countRed).ToString();
        greenScore.text ="Green"+ (FindObjectOfType<Ball>().countGreen).ToString();
        blueScore.text = "Blue"+(FindObjectOfType<Ball>().countBlue).ToString();
    }

    void PreStartGame() {
        Vector3 paddlePos = paddle.gameObject.transform.position;
        Vector3 ballPos = new Vector3(paddlePos.x, paddlePos.y +0.25f , 0);

       if (Input.GetKeyDown(KeyCode.Space))
        {
                startGame = true;
        }               
        

        if (!startGame)
        {
            initialBall.transform.position = ballPos;
        }

    }

    void InitializeBall() 
    {
        Vector3 paddlepos = paddle.gameObject.transform.position;
        Vector3 ballpos = new Vector3(paddlepos.x, paddlepos.y+0.1f, 0);
        initialBall = Instantiate(ballPrefab, ballpos, Quaternion.identity);
    }

    public static bool test_cols(int n)
    {
        if (n > 0 || n <14)
            return true;
        return false;
    }

    public static bool test_rows(int n)
    {
        if (n > 0 || n < 5)
            return true;
        return false;
    }

    void initializeblocks() {
        var startx = -7;
        var stopx = 7;
        var starty = 0;
        var stopy = 4;
        countblocks = _cols * _rows;

        if (!test_cols(_cols) || !test_rows(_rows))
        {
            Debug.Log("Error Rows should be an integer more than 0 and  less than 13, cols should be int greater than 0 and less than 4 ");
        }
        else
        {
            
            var widthx = (Mathf.Abs(startx) + Mathf.Abs(stopx)) / _cols;
            var widthy = (Mathf.Abs(starty) + Mathf.Abs(stopy)) / _rows;

            for (var i = 0; i < _cols; i++)
            {
                for (var j = 0; j < _rows; j++)
                {
                    var x = startx + i + widthx;
                    var y = starty + j + widthy;
                    sprite = blockprefab.GetComponent<SpriteRenderer>();
                    if (i % 3 == 1)
                    {
                        Instantiate(blockprefab, new Vector2(x, y), Quaternion.identity);
                        sprite.color = new Color(1, 0, 0, 1);
                        blockprefab.tag = "Red";
                    }     
                        
                    else if (i % 3 == 2)
                    {
                        Instantiate(blockprefab, new Vector2(x, y), Quaternion.identity);
                        sprite.color = new Color(0, 1, 0, 1);
                        blockprefab.tag = "Green";
                    }
                        
                    else if (i % 3 == 0)
                    {
                        Instantiate(blockprefab, new Vector2(x, y), Quaternion.identity);
                        sprite.color = new Color(0, 0, 1, 1);
                        blockprefab.tag = "Blue";

                    }
                        
                }

            }
        }

    }

    private void Reset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameIsPaused = false;
        }

    }
    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }


}
