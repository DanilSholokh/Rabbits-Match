using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWallController : MonoBehaviour
{



    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameManager.Instance;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            gameManager.ballTouchAll();
            Destroy(gameObject);
        }
    }




}
