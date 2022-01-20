using UnityEngine;

public class Creator : Singleton<Creator> {
    public GameObject Creat(string path) {
        return Loader.Instance.Load(path) as GameObject;
    }
}