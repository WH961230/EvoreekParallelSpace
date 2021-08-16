using System.Collections.Generic;
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

    #region MGR_REGISTER 管理类注册标识
    public string MGR_UPDATE = "MGR_UPDATE";
    public string MGR_FIXEDUPDATE = "MGR_FIXEDUPDATE";
    public string MGR_LATEUPDATE = "MGR_LATEUPDATE";
    #endregion
    
    #region CONTROLLER_REGISTER 控制类注册标识
    public string CONTROLLER_UPDATE = "CONTROLLER_UPDATE";
    public string CONTROLLER_FIXEDUPDATE = "CONTROLLER_FIXEDUPDATE";
    public string CONTROLLER_LATEUPDATE = "CONTROLLER_LATEUPDATE";
    #endregion
    
    

    #region EVENTDIC 事件

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

    #endregion
}
