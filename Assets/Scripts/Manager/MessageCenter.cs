using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

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

public class MessageCenter : Singleton<MessageCenter>
{
    private Dictionary<string, IEvent> eventDic = new Dictionary<string, IEvent>();
    private Dictionary<int, List<Wrapper>> msg = new Dictionary<int, List<Wrapper>>();

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

    public void Register(int code, Action action)
    {
        RegisterMessage(code, action);
    }
    
    public void Register<T>(int code, Action action, T data)
    {
    }

    public void Register<T1, T2>(int code, Action action, T1 data1, T2 data2)
    {
    }

    public void Register<T1, T2, T3>(int code, Action action, T1 data1, T2 data2, T3 data3)
    {
    }

    public void RegisterMessage(int code, Delegate handle)
    {
        List<Wrapper> wrappers;
    }

    public void Dispatcher(int code)
    {
    }
    
    public void Dispatcher<T>(int code, T data)
    {
    }

    public void Dispatcher<T1, T2>(int data, T1 data1, T2 data2)
    {
    }
    
    public void Dispatcher<T1, T2, T3>(int data, T1 data1, T2 data2, T3 data3)
    {
    }

    class Wrapper
    {
        private int code;
        private Delegate handle;

        public Wrapper(int code, Delegate handle)
        {
            this.code = code;
            this.handle = handle;
        }

        public void Invoke()
        {
            ((Action)handle).Invoke();
        }
    }

    #endregion
}
