using System;
using Data;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOperateWin : MonoBehaviour {
    public Text Tip;
    public CrossController CrossController;
    public BloodEffectController BloodEffectController;

    public void Start() {
        MessageCenter.Instance.Register(MessageCode.Tip_BulletNull, ShowTip);
    }

    private void ShowTip() {
        Debug.Log("弹药不足");
    }
}