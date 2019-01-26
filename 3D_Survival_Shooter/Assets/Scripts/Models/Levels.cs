using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels
{
    private bool firstLevelPassed = false;
    private bool secondLevelPassed = false;

    public bool GetFirstLevelPassed()
    {
        return firstLevelPassed;
    }

    public bool GetSecondLevelPassed()
    {
        return secondLevelPassed;
    }

    public void FirstLevelIsPassed()
    {
        firstLevelPassed = true;
    }

    public void SecondLevelIsPassed()
    {
        secondLevelPassed = true;
    }
}
