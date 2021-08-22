using System;
using UnityEngine;

public interface IBaseController
{
    void OnInit();
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}
