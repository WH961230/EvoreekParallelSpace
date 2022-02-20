using System;
using System.Collections.Generic;
using System.Reflection;

public class SceneConfig : IConfig
{
    public readonly string id;
    public readonly string worldId;
    public readonly string sceneSign;
    public readonly int loadType;

    public SceneConfig(string input)
    {
        var tables = input.Split('\t');
        id = tables[0];
        worldId = tables[1];
        sceneSign = tables[2];
        loadType = int.Parse(tables[3]);
    }
    
    private static Dictionary<string, string> rawDatas;
    private static Dictionary<string, GameConfig> configs;
    
    //读取配置文件内容 存入 rawDatas 
    public static void OnInit()
    {
        var txtName = MethodInfo.GetCurrentMethod().DeclaringType.Name;
        txtName = txtName.Substring(0, txtName.IndexOf("Config"));
        var textAsset = Loader.Instance.LoadTxt(txtName);
        var strings = textAsset.text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        rawDatas = new Dictionary<string, string>(strings.Length - 3);
        for (int i = 3 ; i < strings.Length ; i++) {
            var line = strings[i];
            var index = line.IndexOf('\t');
            var id = line.Substring(0, index);

            rawDatas.Add(id, line);
        }
    }

    public static SceneConfig Get(string id) {
        if (string.IsNullOrEmpty(id)) {
            return null;
        }

        if (rawDatas.Count == 0) {
            return null;
        }

        if (!rawDatas.ContainsKey(id)) {
            return null;
        }

        SceneConfig config = null;
        if (rawDatas.ContainsKey(id))
        {
            config = new SceneConfig(rawDatas[id]);
        }

        return config;
    }
}