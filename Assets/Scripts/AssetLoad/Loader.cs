
using System;

public class Loader : Singleton<Loader>
{
    public Object LoadGameEngine()
    {
        return UnityEngine.Resources.Load("Prefabs/Globle/GameEngine");
    }
}