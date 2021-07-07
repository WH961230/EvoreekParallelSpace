using UnityEngine;
using UnityEngine.Events;

public class MonoController : MonoBehaviour
{
    public event UnityAction updateAction;

    public void Update()
    {
        if (null != updateAction)
        {
            updateAction();
        }
    }

    public void AddUpdateEventListener(UnityAction action)
    {
        updateAction += action;
    }

    public void RemoveUpdateEventListener(UnityAction action)
    {
        updateAction -= action;
    }
}
