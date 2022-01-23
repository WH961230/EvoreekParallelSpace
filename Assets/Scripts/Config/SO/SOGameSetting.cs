using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "war/so/gamesetting")]
public class SOGameSetting : ScriptableObject {
    [Tooltip("场景加载类型")][SerializeField] public LoadSceneMode loadSceneMode;
    [Tooltip("初始化场景")][SerializeField] public bool IsInitScene;

    [Tooltip("场景标识")][SerializeField] public string SceneSign;
}