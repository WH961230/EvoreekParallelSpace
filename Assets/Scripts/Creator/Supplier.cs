using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public enum SUPPLIERTYPE {
    Role = 0,
    Weapon = 1,
    Engine = 2,
}

public class Supplier : Singleton<Supplier>
{
    private readonly Dictionary<SUPPLIERTYPE, string> pathDic = new Dictionary<SUPPLIERTYPE, string>();
    private readonly Dictionary<SUPPLIERTYPE,Transform> layerDic = new Dictionary<SUPPLIERTYPE, Transform>() {
        {SUPPLIERTYPE.Role, new GameObject("RoleLayer").transform},
        {SUPPLIERTYPE.Weapon, new GameObject("WeaponLayer").transform},
    };

    public void OnInit()
    {
        var items = ItemConfig.GetAll();
        for (int i = 0; i < items.Count; i++)
        {
            var item = items[i];
            pathDic.Add((SUPPLIERTYPE)item.type, item.path + item.prefab);
        }
    }

    // 获取层级 Transform
    private Transform GetLayer(SUPPLIERTYPE type) {
        if (layerDic.TryGetValue(type, out var target)) {
            return target;
        }

        return null;
    }

    // 创建游戏物体
    public GameObject CreatGameObj(SUPPLIERTYPE type) {
        if (pathDic.TryGetValue(type, out string path)) {
            var parent = GetLayer(type);//层
            var temp = Loader.Instance.Load(path);//获取
            var tempGO = Object.Instantiate(temp as GameObject, parent, true);//创建
            return tempGO;
        }

        return null;
    }

    // 添加组件
    public T AddComponent<T>(GameObject go, long id) where T : MyComponent, new() {
        if (null == go) {
            return null;
        }

        var component = go.AddComponent<T>();
        component.OnInit<T>(id);
        return component;
    }
}