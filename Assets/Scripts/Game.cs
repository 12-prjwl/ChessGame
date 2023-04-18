using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject chesspiece;
    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];

    
    private string currentPlayer = "white"; // the start of the game

  
    private bool gameOver = false;

    void Start()
    {
            playerWhite = new GameObject[] 
            { 
            Create("white_rook", 0, 0), Create("white_knight", 1, 0), // Create("NameOfChesspiece", row1 , row2)0,0 : indicates the 1st row of white pieces, )
            Create("white_bishop", 2, 0), Create("white_queen", 3, 0), Create("white_king", 4, 0),
            Create("white_bishop", 5, 0), Create("white_knight", 6, 0), Create("white_rook", 7, 0),
            Create("white_pawn", 0, 1), Create("white_pawn", 1, 1), Create("white_pawn", 2, 1),
            Create("white_pawn", 3, 1), Create("white_pawn", 4, 1), Create("white_pawn", 5, 1),
            Create("white_pawn", 6, 1), Create("white_pawn", 7, 1) 
            };

        playerBlack = new GameObject[] { Create("black_rook", 0, 7), Create("black_knight",1,7),
            Create("black_bishop",2,7), Create("black_queen",3,7), Create("black_king",4,7),
            Create("black_bishop",5,7), Create("black_knight",6,7), Create("black_rook",7,7),
            Create("black_pawn", 0, 6), Create("black_pawn", 1, 6), Create("black_pawn", 2, 6),
            Create("black_pawn", 3, 6), Create("black_pawn", 4, 6), Create("black_pawn", 5, 6),
            Create("black_pawn", 6, 6), Create("black_pawn", 7, 6) };

            
        //Set all piece positions on the positions board
        for (int i = 0; i < playerBlack.Length; i++)
        {
            SetPosition(playerBlack[i]); // for i=0, rook will be placed on Create("white_rook", 0, 0), and so on..
            SetPosition(playerWhite[i]);
        }


    }
    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, -1), Quaternion.identity);
        ChessPieceMovement cm = obj.GetComponent<ChessPieceMovement>(); 
        cm.name = name; 
        cm.SetXBoard(x); 
        cm.SetYBoard(y);
        cm.Activate(); 
        return obj;
    }
     public void SetPosition(GameObject obj)
    { 
        ChessPieceMovement cm = obj.GetComponent<ChessPieceMovement>();

       
        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }
     public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }
     public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }

     public string GetCurrentPlayer()
    {
        return currentPlayer;
    }


        public bool IsGameOver()
    {
        return gameOver;
    }

    public void NextTurn()
    {
        if (currentPlayer == "white")
        {
            currentPlayer = "black";
        }
        else
        {
            currentPlayer = "white";
        }
    }

    public void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            gameOver = false;

           
            SceneManager.LoadScene("Game"); 
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Start");



    }

    public void Winner(string playerWinner)
    {
        gameOver = true;

       
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().enabled = true;
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().text = playerWinner + " is the winner";

        GameObject.FindGameObjectWithTag("TapToRestart").GetComponent<Text>().enabled = true;
    }










}

    

