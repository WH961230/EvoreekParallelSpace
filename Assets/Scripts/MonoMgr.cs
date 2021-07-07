using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoMgr : Singleton<MonoMgr>
{
    private List<MonoController> controllers = new List<MonoController>();
    public void OnInit()
    {
        var obj = new GameObject("TestGameObj");
        controllers.Add(obj.AddComponent<MonoController>());
        var obj2 = new GameObject("Test2GameObj");
        obj2.AddComponent<MonoController>();
    }

    public void AddUpdateEventListener(UnityAction action)
    {
        foreach (var controller in controllers)
        {
            controller?.AddUpdateEventListener(action);
        }
    }

    public void RemoveUpdateEventListener(UnityAction action)
    {
        foreach (var controller in controllers)
        {
            controller?.RemoveUpdateEventListener(action);
        }
    }
}
