using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallViser : MonoBehaviour
{


    [SerializeField] List<Transform> placeSpawns;

    [SerializeField] MagicWallController wallController; 
    [SerializeField] MagicBombController bombController; 

    private Transform getRandomPlace()
    {
        int num_r = Random.Range(0, placeSpawns.Count);

        return placeSpawns[num_r];

    }    


    public void createWall()
    {

        int num_r = Random.Range(0, 100);

        if (num_r >= 65 && num_r < 85)
        {
            Instantiate(wallController, getRandomPlace());
        }
        else if (num_r >= 85)
        {
            Instantiate(bombController, getRandomPlace());
        }
        
    }
 
    





}
