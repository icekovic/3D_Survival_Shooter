using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    private bool firstLevelPassed;
    private bool secondLevelPassed;

    private void Awake()
    {
        firstLevelPassed = false;
        secondLevelPassed = false;
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

    public void FirstLevelIsPassed()
    {
        firstLevelPassed = true;
    }

    public void SecondLevelIsPassed()
    {
        secondLevelPassed = true;
    }
}
