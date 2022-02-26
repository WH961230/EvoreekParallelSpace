using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class MeshTool {
    
    /// <summary>
    /// 使用方法：将被合并的所有 Mesh 放到父物体(没有 MeshFilter 组件)下，选择父物体，点击该方法。
    /// </summary>
    [MenuItem("资源工具/模型/合并模型")]
    public static void GenerateParse() {
        var go = Selection.GetFiltered(typeof(GameObject), SelectionMode.DeepAssets)[0] as GameObject;
        var childs = go.GetComponentsInChildren<MeshFilter>();
        var childCount = childs.Length;
        var meshFilters = new MeshFilter[childCount];
        for (int i = 0; i < childCount; i++) {
            meshFilters[i] = childs[i];
        }

        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        for (int i = 0; i < meshFilters.Length; i++) {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }
        //create temp object
        var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);

        obj.transform.parent = go.transform;
        var filter = obj.GetComponent<MeshFilter>();
        //remove collider
        Object.DestroyImmediate(obj.GetComponent<Collider>());
        //combine mesh
        filter.mesh.CombineMeshes(combine);
        //restore asset
        AssetDatabase.CreateAsset(filter.sharedMesh, "Assets/Art/Mesh/" + go.name + ".asset");
    }
}