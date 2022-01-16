
using System;

public class Loader
{
    public static Object LoadGameEngine()
    {
        return UnityEngine.Resources.Load("Prefabs/Globle/GameEngine");
    }
}