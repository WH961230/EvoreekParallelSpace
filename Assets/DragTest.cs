using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragTest : MonoBehaviour
{
    private void Update() {
        var pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
        transform.position = pos;
    }
}
