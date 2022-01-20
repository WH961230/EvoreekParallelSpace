
using System;

public class Loader : Singleton<Loader>
{
    public Object Load(string path)
    {
        // return UnityEngine.Resources.Load("Prefabs/Globle/GameEngine");
        return UnityEngine.Resources.Load(path);
    }
}