using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtLocalRole : MonoBehaviour
{
    void Update()
    {
        if (null != GameData.LockPlayer)
        {
            transform.LookAt(GameData.LockPlayer.BaseData.playerController.characterController.transform);
        }
    }
}
