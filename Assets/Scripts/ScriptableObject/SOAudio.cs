using UnityEngine;

[CreateAssetMenu(menuName = "SOAudio", order = 0)]
public class SOAudio : ScriptableObject {
    [SerializeField] [Tooltip("音乐标识")] private string audioMainSign;

    public string AudioMainSign => audioMainSign;
}