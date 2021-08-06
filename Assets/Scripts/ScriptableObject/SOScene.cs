using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SOScene", order = 0)]
public class SOScene : ScriptableObject {
    [SerializeField] [Tooltip("场景A")] private string sceneSign;

    public string SceneSign => sceneSign;
}
