using System.Collections.Generic;
using System.Reflection;
using Data;
using UnityEngine;
using UnityEngine.UI;

public class CrossController : MonoBehaviour, IBaseController {
    public Image CenterPot;
    public Image CrossLeft;
    public Image CrossRight;
    public Image CrossUp;
    public Image CrossDown;

    public Vector3 CrossLetfDefaultVec;
    public Vector3 CrossRightDefaultVec;
    public Vector3 CrossUpDefaultVec;
    public Vector3 CrossDownDefaultVec;

    private float h;
    private float v;

    private bool isMove;
    
    public void SetCrossAndPotColor(Color color) {
        CenterPot.color = color;
        
        CrossLeft.color = color;
        CrossRight.color = color;
        CrossUp.color = color;
        CrossDown.color = color;
    }

    /// <summary>
    /// 十字线随玩家运动
    /// </summary>
    private void SetCrossDinamic(InputMgr.InputData data)
    {
        h = data.horizontal;
        v = data.vertical;
    }

    public void OnInit() {
        MessageCenter.Instance.Register<InputMgr.InputData>(MessageCode.Game_InputData, SetCrossDinamic);
        crossLeftTarget = CrossLeft.transform.localPosition + Vector3.left * crossDistance;
        crossRightTarget = CrossRight.transform.localPosition + Vector3.right * crossDistance;
        crossUpTarget = CrossUp.transform.localPosition + Vector3.up * crossDistance;
        crossDownTarget = CrossDown.transform.localPosition + Vector3.down * crossDistance;
    }

    private Vector3 crossLeftTarget;
    private Vector3 crossRightTarget;
    private Vector3 crossUpTarget;
    private Vector3 crossDownTarget;
    
    public float crossSpeed;
    public float crossDistance;

    public void OnUpdate() {
        if (Mathf.Abs(h) > 0.0001f || Mathf.Abs(v) > 0.000f)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }

        if (isMove)
        {
            if (CrossLeft.transform.localPosition != crossLeftTarget)
            {
                CrossLeft.transform.localPosition = Vector3.Lerp(CrossLeft.transform.localPosition, crossLeftTarget, Time.deltaTime * crossSpeed);
            }
            if (CrossRight.transform.localPosition != crossRightTarget)
            {
                CrossRight.transform.localPosition = Vector3.Lerp(CrossRight.transform.localPosition, crossRightTarget, Time.deltaTime * crossSpeed);
            }
            if (CrossUp.transform.localPosition != crossUpTarget)
            {
                CrossUp.transform.localPosition = Vector3.Lerp(CrossUp.transform.localPosition, crossUpTarget, Time.deltaTime * crossSpeed);
            }
            if (CrossDown.transform.localPosition != crossDownTarget)
            {
                CrossDown.transform.localPosition = Vector3.Lerp(CrossDown.transform.localPosition, crossDownTarget, Time.deltaTime * crossSpeed);
            }
        }
        else
        {
            if (CrossLeft.transform.localPosition != CrossLetfDefaultVec)
            {
                CrossLeft.transform.localPosition = Vector3.Lerp(CrossLeft.transform.localPosition, CrossLetfDefaultVec, Time.deltaTime * crossSpeed);
            }
            if (CrossRight.transform.localPosition != CrossRightDefaultVec)
            {
                CrossRight.transform.localPosition = Vector3.Lerp(CrossRight.transform.localPosition, CrossRightDefaultVec, Time.deltaTime * crossSpeed);
            }
            if (CrossUp.transform.localPosition != CrossUpDefaultVec)
            {
                CrossUp.transform.localPosition = Vector3.Lerp(CrossUp.transform.localPosition, CrossUpDefaultVec, Time.deltaTime * crossSpeed);
            }
            if (CrossDown.transform.localPosition != CrossDownDefaultVec)
            {
                CrossDown.transform.localPosition = Vector3.Lerp(CrossDown.transform.localPosition, CrossDownDefaultVec, Time.deltaTime * crossSpeed);
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
