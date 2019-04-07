using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    private bool firstLevelPassed;
    private bool secondLevelPassed;
    private bool thirdLevelPassed;

    private void Awake()
    {
        firstLevelPassed = false;
        secondLevelPassed = false;
        thirdLevelPassed = false;
    }

    void Start()
    {
        
    }

    public bool GetFirstLevelPassed()
    {
        return firstLevelPassed;
    }

    public bool GetSecondLevelPassed()
    {
        return secondLevelPassed;
    }

    public bool GetThirdLevelPassed()
    {
        return thirdLevelPassed;
    }

    public void FirstLevelIsPassed()
    {
        firstLevelPassed = true;
    }

    public void SecondLevelIsPassed()
    {
        secondLevelPassed = true;
    }

    public void ThirdLevelIsPassed()
    {
        thirdLevelPassed = true;
    }
}
