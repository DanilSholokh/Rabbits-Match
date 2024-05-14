using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{


    [SerializeField] TMP_Text counterUp;
    [SerializeField] TMP_Text counterDown;
    
    [SerializeField] TMP_Text gold;
    [SerializeField] TMP_Text goldMenu;


    public void editUpCounter(int goalScore)
    {
        counterUp.text = goalScore.ToString();
    }
    
    public void editDownCounter(int goalScore)
    {
        counterDown.text = goalScore.ToString();
    }    

    public void editMainGold(int goalScore)
    {
        gold.text = goalScore.ToString();
        goldMenu.text = goalScore.ToString();
    }



}
