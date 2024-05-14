using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGoalDetected : MonoBehaviour
{

    private GameManager gameManager;

    [SerializeField] bool isUpWall;


    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            if (isUpWall)
            {
                gameManager.UpScore++;
            }
            else 
            {
                gameManager.DownScore++;
            }

            gameManager.ballTouchWallTigers();


            gameManager.startGame();
            gameManager.updateTextScore();

        }
    }

}
