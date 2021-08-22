using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager {
    public class SceneMgr : Singleton<SceneMgr> , IBaseMgr {
        public void OnInit(GameEngine engine) {
            engine.managers.Add(this);
            LoadScene(ConfigMgr.Instance.sceneConfig.SceneSign, LoadSceneMode.Additive);
        }

        private void LoadScene(string sceneSign, LoadSceneMode mode)
        {
            SceneManager.LoadScene(sceneSign, mode);
            if (mode == LoadSceneMode.Additive)
            {
                Debug.Log($"加载子场景 {ConfigMgr.Instance.sceneConfig.SceneSign}");
            }
            else
            {
                Debug.Log($"切换场景 {ConfigMgr.Instance.sceneConfig.SceneSign}");
            }
        }

        public void OnUpdate() {
        }

        public void OnClear() {
        }
    }
}