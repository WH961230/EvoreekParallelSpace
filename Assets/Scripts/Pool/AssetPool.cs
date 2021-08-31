using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 资源池 - 资源预加载与提取
/// </summary>
public class AssetPool : Singleton<AssetPool>
{
    private Dictionary<int, Object> objs = new Dictionary<int, Object>();
    public void InPool(int id, Transform transform)
    {
        transform.gameObject.SetActive(false);
        if (objs.ContainsKey(id))
        {
            if (null != objs[id])
            {
                Debug.LogError("资源已在资源池 检查创建了相同物体");
                return;
            }

            objs[id] = transform;
        }
        else
        {
            objs.Add(id, transform);
        }
    }
}