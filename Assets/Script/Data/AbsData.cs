using System;
using System.Collections.Generic;

public interface IBaseData {
    void OnInit(AbsControl myControl);
}

public abstract class AbsData : IBaseData {
#region 信息
    protected int myCode = -1;
    protected List<AbsInfo> AllInfos = new List<AbsInfo>();
#endregion

#region 上层
    protected AbsControl myControl;
#endregion

    public virtual void OnInit(AbsControl control) {
        myControl = control;
    }

    public void AddInfo(AbsInfo info) {
        if (!TryGetInfo(info.Id, out AbsInfo tInfo)) {
            AllInfos?.Add(info);
        }
    }

    public void RemoveInfo(int id) {
        if (TryGetInfo(id, out AbsInfo tInfo)) {
            AllInfos?.Remove(tInfo);
        }
    }

    public void ChangeInfo(int id, AbsInfo info) {
        if (TryGetInfo(id, out AbsInfo temp)) {
            RemoveInfo(id);
            AddInfo(info);
        }
    }

    public bool TryGetInfo(int id, out AbsInfo info) {
        for (var i = 0; i < AllInfos.Count; i++) {
            var tempInfo = AllInfos[i];
            if (id == tempInfo.Id) {
                info = tempInfo;
                return true;
            }
        }

        info = null;
        return false;
    }
    
    public virtual void Create(String prefabName) {
    }
}