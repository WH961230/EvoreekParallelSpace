using UnityEngine;

[CreateAssetMenu(menuName = "SOBullet", order = 0)]
public class SOBullet : ScriptableObject
{
    [Header("==== 弹药 ====")]
    [SerializeField] [Tooltip("弹药标识")] private string bulletSign;
    public string BulletSign => bulletSign;
}
