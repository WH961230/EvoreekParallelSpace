using UnityEngine;

public class Creator : Singleton<Creator> {
    public GameObject Creat<T>() where T : MonoBehaviour, new() {
        return Loader.Instance.LoadGameEngine() as GameObject;
    }
}