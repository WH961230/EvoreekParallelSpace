﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager {
    public class SceneMgr : Singleton<SceneMgr> , IBaseMgr {
        public void OnInit(GameEngine engine) {
            engine.managers.Add(this);
            SceneManager.LoadScene(ConfigMgr.Instance.sceneConfig.SceneSign, LoadSceneMode.Additive);
            Debug.Log($"加载子场景 {ConfigMgr.Instance.sceneConfig.SceneSign}");
        }

        public void OnUpdate() {
        }

        public void OnClear() {
        }
    }
}