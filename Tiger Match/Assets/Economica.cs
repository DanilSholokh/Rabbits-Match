using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Economica : MonoBehaviour
{
    public int startingGold = 1000; 
    private int currentGold;

    void Start()
    {

       currentGold = PlayerPrefs.GetInt("Gold", startingGold);

    }

    void SaveGold()
    {
        PlayerPrefs.SetInt("Gold", currentGold);
        PlayerPrefs.Save();
    }

    public void AddGold(int amount)
    {
        currentGold += amount;
        SaveGold();
    }

    public void SubtractGold(int amount)
    {
        currentGold -= amount;
 
        if (currentGold < 0)
        {
            currentGold = 0;
        }
        SaveGold();

    }

    public int GetCurrentGold()
    {
        return PlayerPrefs.GetInt("Gold", startingGold);
    }

}
