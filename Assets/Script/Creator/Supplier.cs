using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public enum SUPPLIERTYPE {
    Role = 0,
    Item = 1,
    Scene = 2,
}

public class Supplier : Singleton<Supplier> {
    private readonly Dictionary<string, string> pathDic = new Dictionary<string, string>();
    private readonly Dictionary<SUPPLIERTYPE, Transform> layerDic = new Dictionary<SUPPLIERTYPE, Transform>() {
        {SUPPLIERTYPE.Role, new GameObject("RoleLayer").transform},
        {SUPPLIERTYPE.Item, new GameObject("ItemLayer").transform},
    };

    public Supplier() {
        var items = PrefabConfig.GetAll();
        for (int i = 0; i < items.Count; i++) {
            var item = items[i];
            pathDic.Add(item.prefab, item.path + item.prefab);
        }
    }

    private Transform GetLayer(SUPPLIERTYPE type) {
        if (layerDic.TryGetValue(type, out var target)) {
            return target;
        }

        return null;
    }

    public bool CreatInstance<T>(AbsControl control, string prefabName, out int instanceId) where T : AbsComponent, new(){
        if (pathDic.TryGetValue(prefabName, out string path)) {
            var parent = GetLayer(control.myType);
            var temp = Loader.Instance.Load(path);
            var tempGO = Object.Instantiate(temp as GameObject, parent, true);
            if (null != tempGO) {
                var component = tempGO.AddComponent<T>();
                instanceId = component.GetInstanceID();
                component.OnInit<T>(control, instanceId);
                return true;
            }
        }

        instanceId = 0;
        return false;
    }
}