using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoMgr : Singleton<MonoMgr>
{
    private List<MonoController> controllers = new List<MonoController>();

    public void OnInit()
    {
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