using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyManager
{
    private static int zombunnyValue = 10;
    private static int zombearValue = 15;
    private static int hellephantValue = 20;

    private static int zombunnyAmount = 10;
    private static int zombearAmount = 15;
    private static int hellephantAmount = 20;

    public static int GetZombunnyValue()
    {
        return zombunnyValue;
    }

    public static int GetZombearValue()
    {
        return zombunnyValue;
    }

    public static int GetHellephantValue()
    {
        return hellephantValue;
    }

    public static int GetZombunnyAmount()
    {
        return zombunnyAmount;
    }

    public static int GetZombearAmount()
    {
        return zombearAmount;
    }

    public static int GetHellephantAmount()
    {
        return hellephantAmount;
    }
}
