using System;
using Data;
using UnityEngine;
using UnityEngine.UI;

public class CrossController : MonoBehaviour, IBaseController {

    [Serializable]
    public class CrossData {
        public Image CrossImage;
        public Vector3 CrossCurrentVec;
        public Vector3 CrossDefaultVec;
        public Vector3 CrossTargetVec;
        public float LerpSpeed;
    }

    //准心数据
    public CrossData[] crossDatas;

    private float h;
    private float v;

    private bool isMove;

    public void OnInit() {
        MessageCenter.Instance.Register<InputMgr.InputData>(MessageCode.Game_InputData, SetCrossDinamic);
        InitCrossData();
    }

    public void OnUpdate() {
        CheckMoveEvent();
        LerpCrossEvent();
    }

    /// <summary>
    /// 玩家移动检测
    /// </summary>
    private void CheckMoveEvent() {
        if (Mathf.Abs(h) > 0.0001f || Mathf.Abs(v) > 0.000f) {
            isMove = true;
        } else {
            isMove = false;
        }
    }

    /// <summary>
    /// 准心平滑运动事件
    /// </summary>
    private void LerpCrossEvent() {
        if (isMove) {
            LerpCrossTarget();
        } else {
            LerpCrossDefault();
        }
    }

    /// <summary>
    /// 设置准心颜色
    /// </summary>
    /// <param name="color"></param>
    public void SetCrossColor(Color color) {
        foreach (var c in crossDatas) {
            var i = c.CrossImage;
            if (null != i) {
                i.color = color;
            }
        }
    }

    /// <summary>
    /// 准心随玩家运动
    /// </summary>
    private void SetCrossDinamic(InputMgr.InputData data) {
        h = data.horizontal;
        v = data.vertical;
    }

    /// <summary>
    /// 初始化准心数据
    /// </summary>
    private void InitCrossData() {
    }

    /// <summary>
    /// 准心偏移
    /// </summary>
    private void LerpCrossTarget() {
        if (crossDatas.Length > 0) {
            foreach (var c in crossDatas) {
                c.CrossCurrentVec = c.CrossImage.transform.localPosition;
                if (Vector3.Distance(c.CrossCurrentVec, c.CrossTargetVec) > 0.0001f) {
                    var t = c.CrossImage.transform;
                    var target = c.CrossTargetVec;
                    t.localPosition = Vector3.Lerp(t.localPosition, target, Time.deltaTime * c.LerpSpeed);
                }
            }
        }
    }

    /// <summary>
    /// 准心恢复
    /// </summary>
    private void LerpCrossDefault() {
        foreach (var c in crossDatas) {
            c.CrossCurrentVec = c.CrossImage.transform.localPosition;
            if (Vector3.Distance(c.CrossCurrentVec, c.CrossDefaultVec) > 0.0001f) {
                var t = c.CrossImage.transform;
                var d = c.CrossDefaultVec;
                t.localPosition = Vector3.Lerp(t.localPosition, d, Time.deltaTime * c.LerpSpeed);
            }
        }
    }

    public void OnFixedUpdate() {
    }

    public void OnLateUpdate() {
    }

    public void OnClear() {
    }
}