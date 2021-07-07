using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameMgr : MonoBehaviour
{
    void Start()
    {
        MonoMgr.GetInstance().OnInit();
        InputMgr.GetInstance().OnInit();
    }
}
