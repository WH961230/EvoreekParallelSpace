using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
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
    private Dictionary<int, List<Wrapper>> handlers;

    #region EVENTDIC 事件

    public MessageCenter() {
        handlers = new Dictionary<int, List<Wrapper>>();
    }
    
    public void Register(int id, Action handler) {
        RegisterDelegate(id, handler);
    }
    
    public void Register<T>(int id, Action<T> handler) {
        RegisterDelegate(id, handler);
    }

    public void Register<T1, T2>(int id, Action<T1, T2> handler) {
        RegisterDelegate(id, handler);
    }

    public void Register<T1, T2, T3>(int id, Action<T1, T2, T3> handler)
    {
        RegisterDelegate(id, handler);
    }

    private void RegisterDelegate(int id, Delegate handler) {
        if (null == handler) return;
        //不存在封装体
        if (!handlers.TryGetValue(id, out var wps)) {
            //新建封装体
            wps = new List<Wrapper>();
            //添加封装体
            handlers.Add(id, wps);
        }

        //不存在委托
        if (SearchWrapperIndex(wps, handler) == -1) {
            //添加委托
            wps.Add(new Wrapper(id, handler));
        }
    }

    private int SearchWrapperIndex(List<Wrapper> list, Delegate handler) {
        int index = -1;
        int length = list.Count;
        for (var i = 0 ; i < length ; ++i) {
            if (list[i].handler == handler) {
                index = i;
                break;
            }
        }

        return index;
    }

    public void Dispatcher(int id)
    {
        if (handlers.TryGetValue(id, out var wps)) {
            var length = wps.Count;
            for (var i = 0 ; i < length ; ++i) {
                wps[i].Invoke();
            }
        }
    }

    public void Dispatcher<T>(int id, T data)
    {
        if (handlers.TryGetValue(id, out var wps)) {
            var length = wps.Count;
            for (var i = 0 ; i < length ; ++i) {
                wps[i].Invoke(data);
            }
        }
    }

    public void Dispatcher<T1, T2>(int id, T1 data1, T2 data2)
    {
        if (handlers.TryGetValue(id, out var wps)) {
            var length = wps.Count;
            for (var i = 0 ; i < length ; ++i) {
                wps[i].Invoke(data1, data2);
            }
        }
    }

    public void Dispatcher<T1, T2, T3>(int id, T1 data1, T2 data2, T3 data3)
    {
        if (handlers.TryGetValue(id, out var wps)) {
            var length = wps.Count;
            for (var i = 0 ; i < length ; ++i) {
                wps[i].Invoke(data1, data2, data3);
            }
        }
    }

    struct Wrapper
    {
        public int id;
        public Delegate handler;

        public Wrapper(int id, Delegate handler)
        {
            this.id = id;
            this.handler = handler;
        }
        public void Invoke()
        {
            ((Action)handler).Invoke();
        }        
        public void Invoke<T>(T data)
        {
            ((Action<T>)handler).Invoke(data);
        }        
        public void Invoke<T1, T2>(T1 data1, T2 data2)
        {
            ((Action<T1, T2>)handler).Invoke(data1, data2);
        }
        public void Invoke<T1, T2, T3>(T1 data1, T2 data2, T3 data3)
        {
            ((Action<T1, T2, T3>)handler).Invoke(data1, data2, data3);
        }
    }

    #endregion
}
