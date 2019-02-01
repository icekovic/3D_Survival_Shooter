using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{
    private int firstLevelEnemyAmount = 10;
    private int secondLevelEnemyAmount = 15;
    private int thirdLevelEnemyAmount = 20;

    public void DecrementFirstLevelEnemyAmount()
    {
        firstLevelEnemyAmount--;
    }

    public void DecrementSecondLevelEnemyAmount()
    {
        secondLevelEnemyAmount--;
    }

    public void DecrementThirdLevelEnemyAmount()
    {
        thirdLevelEnemyAmount--;
    }

    public int FirstLevelEnemyAmount()
    {
        return firstLevelEnemyAmount;
    }

    public int SecondLevelEnemyAmount()
    {
        return secondLevelEnemyAmount;
    }

    public int ThirdLevelEnemyAmount()
    {
        return thirdLevelEnemyAmount;
    }
}
