using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterGoal : MonoBehaviour
{

    private int limit = 2;
    
    public bool isGoalLoose(int goal_one, int goal_two)
    {
        if (goal_one - limit > goal_two)
        {
            return true;
        }
        else if (goal_two - limit > goal_one)
        {
            return true;
        }

        return false;

    }


}
