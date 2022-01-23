using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public enum SUPPLIERTYPE {
    Role, 
    Engine,
}

public class Supplier : Singleton<Supplier> {
    private readonly Dictionary<SUPPLIERTYPE,string> pathDic = new Dictionary<SUPPLIERTYPE, string>() {
        {SUPPLIERTYPE.Role, "Prefabs/Role/Role"},
        {SUPPLIERTYPE.Engine, "Prefabs/Global/GameEngine"}
    };

    private readonly Dictionary<SUPPLIERTYPE,Transform> layerDic = new Dictionary<SUPPLIERTYPE, Transform>() {
        {SUPPLIERTYPE.Role, null},
        {SUPPLIERTYPE.Engine, null}
    };

    public void InitLayer() {
        var keys = layerDic.Keys;
        foreach (var key in keys) {
            if (key == SUPPLIERTYPE.Role) {
                var layer = new GameObject("RoleLayer");
                layerDic[key] = layer.transform;
            }
        }
    }

    private Transform GetLayer(SUPPLIERTYPE type) {
        if (layerDic.TryGetValue(type, out var target)) {
            return target;
        }

        return null;
    }

    /// <summary>
    /// 创建游戏物体
    /// </summary>
    /// <param name="type">类型</param>
    /// <returns></returns>
    public GameObject CreatGameObj(SUPPLIERTYPE type) {
        if (pathDic.TryGetValue(type, out string path)) {
            var parent = GetLayer(type);//层
            var temp = Loader.Instance.Load(path);//获取
            var tempGO = Object.Instantiate(temp as GameObject, parent, true);//创建
            return tempGO;
        }

        return null;
    }

    /// <summary>
    /// 添加组件
    /// </summary>
    /// <param name="type">类型</param>
    /// <param name="go">物体</param>
    /// <param name="target">组件</param>
    /// <typeparam name="T">组件类型</typeparam>
    /// <returns></returns>
    public T AddComponent<T>(GameObject go, MyControl control, long id) where T : MyComponent, new() {
        if (null == go) {
            return null;
        }

        var component = go.AddComponent<T>();
        // component.OnInit<T>(control, id);
        return component;
    }
}