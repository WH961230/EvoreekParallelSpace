using System;
using UnityEngine;

public interface BaseController
{
    void OnInit();
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnClear();
}
