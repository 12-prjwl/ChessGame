using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlateMovement : MonoBehaviour
{
   
    
    public GameObject controller;

    
    GameObject reference = null;

  
 
    int matrixX;
    int matrixY;

   
    public bool attack = false;

    [SerializeField] private AudioSource killKingSound;



    //ChessPieceMovement cp = null;

    public void Start()
    {
        if (attack)
        {
        
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        

        
        if (attack)
        {
           

            GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

           
            

            if (cp != null)
            {
                if (cp.name == "white_king") controller.GetComponent<Game>().Winner("Black");
                
                
                if (cp.name == "black_king") controller.GetComponent<Game>().Winner("White");
                
            }
            
            Debug.Log(cp);

            //if (cp.name == "white_king") controller.GetComponent<Game>().Winner("black");
            //if (cp.name == "black_king") controller.GetComponent<Game>().Winner("white");
            Destroy(cp);
            killKingSound.Play();







        }

        
        controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<ChessPieceMovement>().GetXBoard(), 
            reference.GetComponent<ChessPieceMovement>().GetYBoard());

        
        reference.GetComponent<ChessPieceMovement>().SetXBoard(matrixX);
        reference.GetComponent<ChessPieceMovement>().SetYBoard(matrixY);
        reference.GetComponent<ChessPieceMovement>().SetCoords();

        
        controller.GetComponent<Game>().SetPosition(reference);

          
        controller.GetComponent<Game>().NextTurn();

        
        reference.GetComponent<ChessPieceMovement>().DestroyMovePlates();
    }
    


    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }

}

