using UnityEngine;
using Object = System.Object;

public class Loader : Singleton<Loader> {
    private readonly string CONFIGPATH = "";
    private readonly string TXTPATH = "Configs/Txt/";
    public Object Load(string path)
    {
        return Resources.Load(path);
    }

    public T LoadConfig<T>(string configName) where T : ScriptableObject, new() {
        return Resources.Load(CONFIGPATH) as T;
    }

    public TextAsset LoadTxt(string txtName) {
        return Resources.Load(TXTPATH + txtName) as TextAsset;
    }
}