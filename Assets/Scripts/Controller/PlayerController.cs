using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    void Start() {
        Init();
    }

    void Init() {
        GlobalData.player = this;
    }

    void Update()
    {
        
    }
}
