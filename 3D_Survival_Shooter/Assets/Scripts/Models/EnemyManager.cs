using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{
    private int zombunnyAmount = 10;
    private int zombearAmount = 15;
    private int hellephantAmount = 20;

    private int zombunnyValue = 10;
    private int zombearValue = 15;
    private int hellephantValue = 20;

    public void DecrementZombunnyAmount()
    {
        zombunnyAmount--;
    }

    public void DecrementZombearAmount()
    {
        zombearAmount--;
    }

    public void DecrementHellephantAmount()
    {
        hellephantAmount--;
    }

    public int GetZombunnyAmount()
    {
        return zombunnyAmount;
    }

    public int GetZombearAmount()
    {
        return zombearAmount;
    }

    public int GetHellephantAmount()
    {
        return hellephantAmount;
    }

    public int GetZombunnyValue()
    {
        return zombunnyValue;
    }

    public int GetZombearValue()
    {
        return zombearValue;
    }

    public int GetHellephantValue()
    {
        return hellephantValue;
    }
}
