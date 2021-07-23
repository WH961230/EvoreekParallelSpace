using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

// 事件接口
public interface IEvent{

}

class EventInfo : IEvent
{
    public UnityAction actions;
    public EventInfo(UnityAction action)
    {
        actions += action;
    }
}

public class EventMgr : Singleton<EventMgr>
{
    private Dictionary<string, IEvent> eventDic = new Dictionary<string, IEvent>();

    public void AddEventListener(string methodName, UnityAction action)
    {
        if (eventDic.ContainsKey(methodName))
        {
            (eventDic[methodName] as EventInfo).actions += action;
        }
        else
        {
            eventDic.Add(methodName, new EventInfo(action));
        }
        Debug.Log($"注册成功事件： {methodName} 方法：{action.Method.Name}");
    }

    public void EventTrigger(string methodName)
    {
        if (eventDic.ContainsKey(methodName))
        {
            (eventDic[methodName] as EventInfo).actions?.Invoke();
        }
    }

    public void RemoveEventListener(string methodName, UnityAction action)
    {
        if (eventDic.ContainsKey(methodName))
        {
            (eventDic[methodName] as EventInfo).actions -= action;
        }
    }
}
