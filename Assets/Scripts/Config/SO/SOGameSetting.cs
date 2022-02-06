using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "war/so/gamesetting")]
public class SOGameSetting : ScriptableObject {
    [Tooltip("测试参数")][SerializeField] public string TestStr;
}