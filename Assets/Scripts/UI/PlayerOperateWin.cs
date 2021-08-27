using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerOperateWin : MonoBehaviour {
    public Text Tip;
    private RaycastHit hit;

    void Update() {
        var ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Item"))) {
            Tip.text = hit.collider.GetComponent<WeaponController>().weaponName;
            if (Input.GetKeyDown(KeyCode.F)) {
                var id = hit.collider.GetComponent<WeaponController>().weaponId;
                var weapon = WeaponMgr.Instance.GetWeaponById(id);
                if (null != weapon) {
                    PlayerWeaponHandle.Instance.PlayerPickWeapon(GameData.LockPlayer.BaseData.id, id);
                    var player = PlayerMgr.Instance.GetPlayerById(GameData.LockPlayer.BaseData.id);
                    player.BaseData.playerController.weaponTran = hit.collider.transform;
                }
            }
        } else {
            Tip.text = "";
        }
    }
}