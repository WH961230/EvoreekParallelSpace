using UnityEngine;

[CreateAssetMenu(menuName = "SOUI", order = 0)]
public class SOUI : ScriptableObject {
    [Header("==== UI 战斗相关信息 ====")] [SerializeField] [Tooltip("血量飚出标识")]
    private string bloodNumFlyOutSign; 

    public string BloodNumFlyOutSign => bloodNumFlyOutSign;
}
