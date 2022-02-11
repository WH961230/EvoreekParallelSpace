using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 世界管理
/// </summary>
public class WorldManager {
    private Engine engine; //引擎
    private List<IWorld> IWorlds = new List<IWorld>();
    private Dictionary<Type, IWorld> IWorldDic = new Dictionary<Type, IWorld>();
    private Dictionary<long, IWorld> worldDic = new Dictionary<long, IWorld>();

    public void OnInit(Engine engine) {
        this.engine = engine;
        engine.AddUpdateAction(OnUpdate);
        engine.AddFixedUpdateAction(OnFixedUpdate);
        engine.AddLateUpdateAction(OnLateUpdate);
        engine.AddQuitAction(OnClear);
    }

    private void OnUpdate() {
        int count = IWorlds.Count;
        for (int i = 0; i < count; i++) {
            IWorlds[i].OnUpdate();
        }
    }

    private void OnFixedUpdate() {
        int count = IWorlds.Count;
        for (int i = 0; i < count; i++) {
            IWorlds[i].OnFixedUpdate();
        }
    }

    private void OnLateUpdate() {
        int count = IWorlds.Count;
        for (int i = 0; i < count; i++) {
            IWorlds[i].OnLateUpdate();
        }
    }

    private void OnClear() {
        engine.RemoveUpdateAction(OnUpdate);
        engine.RemoveFixedUpdateAction(OnFixedUpdate);
        engine.RemoveLateUpdateAction(OnLateUpdate);
        engine.RemoveQuitAction(OnClear);
        engine.Quit();
        engine = null;
    }

    public void AddWorld<T>(WorldInfo info) where T : IWorld, new() {
        var id = info.WorldId;
        if (id == -1) {
            Debug.LogError($"世界管理器添加世界失败 原因：worldId 读取为 -1");
            return;
        }

        if (worldDic.TryGetValue(id, out var target)) {
            Debug.LogError($"重复创建世界[{info.WorldSign}]");
            return;
        }

        IWorld e = new T();
        IWorlds.Add(e);
        worldDic.Add(id, e);
        e.OnInit(info);
    }

    private T GetWorld<T>(long id) {
        if (worldDic.TryGetValue(id, out IWorld target)) {
            return (T)target;
        }

        return default;
    }

    private void RemoveWorld<T>() where T : IWorld, new() {
        var index = FindWorldIndex<T>();
        if (index >= 0) {
            IWorld e = IWorlds[index];
            IWorlds.RemoveAt(index);
            IWorldDic.Remove(e.GetType());
            e.OnClear();
        }
    }

    private int FindWorldIndex<T>() where T : IWorld, new() {
        for (var i = 0; i < IWorldDic.Count; ++i) {
            if (IWorlds[i].GetType() == typeof(T)) {
                return i;
            }
        }

        return -1;
    }
}