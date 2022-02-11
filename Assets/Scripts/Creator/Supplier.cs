using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public enum SUPPLIERTYPE {
    Role = 0,
    Weapon = 1,
    Engine = 2,
}

public class Supplier
{
    private readonly Dictionary<SUPPLIERTYPE, string> pathDic = new Dictionary<SUPPLIERTYPE, string>();
    private readonly Dictionary<SUPPLIERTYPE,Transform> layerDic = new Dictionary<SUPPLIERTYPE, Transform>() {
        {SUPPLIERTYPE.Role, new GameObject("RoleLayer").transform},
        {SUPPLIERTYPE.Weapon, new GameObject("WeaponLayer").transform},
    };

    public Supplier(AbsWorld absWorld)
    {
        var items = ItemConfig.GetAll();
        for (int i = 0; i < items.Count; i++)
        {
            var item = items[i];
            pathDic.Add((SUPPLIERTYPE)item.type, item.path + item.prefab);
        }
    }

    private Transform GetLayer(SUPPLIERTYPE type) {
        if (layerDic.TryGetValue(type, out var target)) {
            return target;
        }

        return null;
    }

    public GameObject CreatGameObj(SUPPLIERTYPE type) {
        if (pathDic.TryGetValue(type, out string path)) {
            var parent = GetLayer(type);//层
            var temp = Loader.Instance.Load(path);//获取
            var tempGO = Object.Instantiate(temp as GameObject, parent, true);//创建
            return tempGO;
        }

        return null;
    }

    public T BundleComponent<T>(MyControl control, GameObject go, long comId) where T : MyComponent, new() {
        if (null == go) {
            return null;
        }

        var component = go.AddComponent<T>();
        component.OnInit<T>(control, comId);
        return component;
    }
}