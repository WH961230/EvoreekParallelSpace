using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "war/so/role")]
public class SORole : AbsSO {
    public float MoveSpeed_Forward = 1;
    public float MoveSpeed_Back = 0.5f;
    public float MoveSpeed_Left = 0.5f;
    public float MoveSpeed_Right = 0.5f;
    public float MoveSpeed_Up = 3f;
    public float MoveSpeed_Down = 0.5f;
}