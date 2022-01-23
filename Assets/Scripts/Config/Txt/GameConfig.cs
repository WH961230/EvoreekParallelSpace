using System;
using System.Collections.Generic;
using System.Reflection;

public class GameConfig : IConfig{
    public readonly string id;
    public readonly string configSign;

    public GameConfig() {
        Init();
    }

    private static Dictionary<string, string> rawDatas;
    private static Dictionary<string, GameConfig> configs;

    //读取配置文件内容 存入 rawDatas 
    public void Init() {
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

    public static GameConfig Get(string id) {
        if (string.IsNullOrEmpty(id)) {
            return null;
        }

        if (rawDatas.Count == 0) {
            return null;
        }

        if (!rawDatas.ContainsKey(id)) {
            return null;
        }

        var temp = rawDatas[id];
        var tempStr = temp.Split('\t');

        for (int i = 0 ; i < tempStr.Length; i++) {
            
        }

        GameConfig config = null;

        return null;
    }
}
