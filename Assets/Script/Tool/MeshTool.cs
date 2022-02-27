using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class MeshTool {
    /// <summary>
    /// 使用方法：将被合并的所有 Mesh 放到父物体(没有 MeshFilter 组件)下，选择父物体，点击该方法，生成 mesh 于 Art 仓。ps:非运行时使用报错不影响
    /// </summary>
    [MenuItem("资源工具/模型/合并模型")]
    public static void GenerateParse() {
        var go = Selection.GetFiltered(typeof(GameObject), SelectionMode.DeepAssets)[0] as GameObject;
        var meshFilters = go.GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        for (int i = 0; i < meshFilters.Length; i++) {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }
        var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.transform.parent = go.transform;
        var filter = obj.GetComponent<MeshFilter>();
        Object.DestroyImmediate(obj.GetComponent<Collider>());
        filter.mesh = new Mesh();
        filter.mesh.CombineMeshes(combine);
        AssetDatabase.CreateAsset(filter.sharedMesh, "Assets/Art/Mesh/" + go.name + ".asset");
    }
}