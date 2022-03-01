using System;
using System.Collections.Generic;

public static class MessageCenter {
    public static void RegisterMessage(int id, Action action) {
        MessageRegister.Register(id, action);
    }

    public static void RegisterMessage<T>(int id, Action<T> action) {
        MessageRegister.Register(id, action);
    }

    public static void UnRegisterMessage(int id) {
        MessageRegister.UnRegister(id);
    }

    public static void DispatcherMessage(int id) {
        MessageRegister.Dispatcher(id);
    }

    public static void DispatcherMessage<T>(int id, T t) {
        MessageRegister.Dispatcher(id, t);
    }
}

/// <summary>
/// 注册机
/// </summary>
public static class MessageRegister {
    private static Dictionary<int, Act> dic = new Dictionary<int, Act>();

    public static void Register(int id, Delegate e) {
        if (!dic.TryGetValue(id, out var temp)) {
            dic.Add(id, new Act(e));
        }
    }

    public static void UnRegister(int id) {
        if (dic.TryGetValue(id, out var temp)) {
            dic.Remove(id);
        }
    }

    public static void Dispatcher(int id) {
        if (dic.TryGetValue(id, out var temp)) {
            temp.Invoke();
        }
    }

    public static void Dispatcher<T>(int id, T t) {
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
        ((Action) deletage)?.Invoke();
    }

    public void Invoke<T>(T t) {
        ((Action<T>) deletage)?.Invoke(t);
    }
}