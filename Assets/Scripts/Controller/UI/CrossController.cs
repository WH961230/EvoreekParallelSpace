using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UI;

public class CrossController : MonoBehaviour, IBaseController {
    public Image CenterPot;
    public Image[] CrossAndPot;
    private Dictionary<Image, Transform> crossImageAndTran = new Dictionary<Image, Transform>();
    
    public void SetCrossAndPotColor(Color color) {
        CenterPot.color = color;
        foreach (var c in CrossAndPot)
        {
            c.color = color;
        }
    }

    /// <summary>
    /// 十字线随玩家运动
    /// </summary>
    private void SetCrossDinamic(InputMgr.InputData data) {
    }

    public void OnInit() {
        MessageCenter.Instance.Register<InputMgr.InputData>(MessageCode.Game_InputData, SetCrossDinamic);
        foreach (var c in CrossAndPot) {
            crossImageAndTran.Add(c, c.transform);
        }
    }

    public void OnUpdate() {
    }

    public void OnFixedUpdate() {
    }

    public void OnLateUpdate() {
    }

    public void OnClear() {
    }
}
