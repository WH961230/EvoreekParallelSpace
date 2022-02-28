using System;
using System.Collections.Generic;
using UnityEngine.AI;

public class MessageCenter {
    private Engine myEngine;
    private MessageRegister myRegister;

    public void OnInit(Engine engine) {
        myEngine = engine;
        myRegister = new MessageRegister();
    }

    public void OnClear() {
        myEngine = null;
        myEngine = null;
    }

    public void Register(int id, Action action) {
        myRegister.Register(id, action);
    }

    public void RegisterMessage<T>(int id, Action<T> action) {
        myRegister.Register(id, action);
    }

    public void UnRegisterMessage(int id) {
        myRegister.UnRegister(id);
    }

    public void DispatcherMessage(int id) {
        myRegister.Dispatcher(id);
    }

    public void DispatcherMessage<T>(int id, T t) {
        myRegister.Dispatcher<T>(id, t);
    }
}

/// <summary>
/// 注册机
/// </summary>
public class MessageRegister {
    private Dictionary<int, Act> dic = new Dictionary<int, Act>();

    public void Register(int id, Delegate e) {
        if (!dic.TryGetValue(id, out var temp)) {
            dic.Add(id, new Act(e));
        }
    }

    public void UnRegister(int id) {
        if (dic.TryGetValue(id, out var temp)) {
            dic.Remove(id);
        }
    }

    public void Dispatcher(int id) {
        if (dic.TryGetValue(id, out var temp)) {
            temp.Invoke();
        }
    }

    public void Dispatcher<T>(int id, T t) {
        if (dic.TryGetValue(id, out var temp)) {
            temp.Invoke(t);
        }
    }
}

/// <summary>
/// 响应机
/// </summary>
public class Act {
    private Delegate deletage;

    public Act(Delegate deletage) {
        this.deletage = deletage;
    }

    public void Invoke() {
        ((Action) deletage).Invoke();
    }

    public void Invoke<T>(T t) {
        ((Action<T>) deletage).Invoke(t);
    }
}