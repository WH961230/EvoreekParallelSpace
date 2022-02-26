using System;
using System.Collections.Generic;
using System.Reflection;

public class ItemConfig : IConfig
{
    public readonly string id;
    public readonly int type;
    public readonly string path;
    public readonly string prefab;

    private ItemConfig(string input) {
        var tables = input.Split('\t');
        id = tables[0];
        type = int.Parse(tables[1]);
        path = tables[2];
        prefab = tables[3];
    }

    private static Dictionary<string, string> rawDatas;
    private static Dictionary<string, ItemConfig> configs;

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

    public static ItemConfig Get(string id) {
        if (string.IsNullOrEmpty(id)) {
            return null;
        }

        if (rawDatas.Count == 0) {
            return null;
        }

        if (!rawDatas.ContainsKey(id)) {
            return null;
        }

        return new ItemConfig(rawDatas[id]);
    }

    public static List<ItemConfig> GetAll()
    {
        if (rawDatas.Count == 0) {
            return null;
        }

        List<ItemConfig> itemConfigs = new List<ItemConfig>();
        for (var i = 1; i <= rawDatas.Count; i++)
        {
            var str = rawDatas[Convert.ToString(i)];
            itemConfigs.Add(new ItemConfig(str));
        }

        return itemConfigs;
    }
}