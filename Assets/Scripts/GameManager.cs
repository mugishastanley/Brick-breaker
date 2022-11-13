using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ball initialBall;
    public Ball ballPrefab;

    public Paddle paddle;
    public static Boolean gamestarted;
    public static Boolean startGame;

    public Text EndScreen;
    public int count;
    private int _countballs;

    // Start is called before the first frame update
    void Start()
    {
        
        InitializeBall();
    }

    // Update is called once per frame
    void Update()
    {
        PreStartGame();
        YouWin();
    }

    void YouWin() {
        GameObject[] blocks;
        blocks = GameObject.FindGameObjectsWithTag("Block");
        count = blocks.Length;
        if (count == 0) {
            EndScreen.text = "YouWin!!";
        }
        if (initialBall == null)
            EndScreen.text = " You Lose !!";
    }

    void PreStartGame() {
        Vector3 paddlePos = paddle.gameObject.transform.position;
        Vector3 ballPos = new Vector3(paddlePos.x, paddlePos.y * .25f, 0);

        if (Input.GetMouseButtonDown(0))
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

    void initializeblocks() {
        float startBlue = -6.0f;
        float EndBlue = -4.0f;
        float startGreen = -2.0f;
        float EndGreen = -2.0f;
        float startRed = 4.0f;
        float endRed = 6.0f;

        for (int i=0; i< _countballs; i++)
        {


        }


    }
}
