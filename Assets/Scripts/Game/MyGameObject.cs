using UnityEngine;
using Object = UnityEngine.Object;

public class MyGameObject : Object
{
    public static Object Instantiate(Object origin)
    {
        var obj = Object.Instantiate(origin);
        if (obj)
        {
            Debug.Log("生成物体：" + obj.name);
        }
        else
        {
            Debug.LogError("错误：生成物体：" + obj.name);
            obj = null;
        }
        return obj;
    }
}