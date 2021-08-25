using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerOperateWin : MonoBehaviour
{
    public Text Tip;
    private RaycastHit hit;

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
        if (Physics.Raycast(ray, out hit, Mathf.Infinity,1 << LayerMask.NameToLayer("Item")))
        {
            Debug.Log(hit.collider.name);
            Tip.text = hit.collider.GetComponent<WeaponController>().weaponName;
            if (Input.GetKeyDown(KeyCode.F))
            {
                var id = hit.collider.GetComponent<WeaponController>().weaponId;
                //武器移除
                WeaponMgr.Instance.RemoveWeapon(id);
                //玩家获得武器
                PlayerMgr.Instance.GetWeapon(PlayerMgr.Instance.GetLocalPlayerId, id);
            }
        }
        else
        {
            Tip.text = "";
        }
    }
}
