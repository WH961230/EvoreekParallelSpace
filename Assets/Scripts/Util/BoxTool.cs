using UnityEngine;

public static class BoxTool
{
    public static void CreateShape(string sign, PrimitiveType t, Vector3 p, Color c, float small)
    {
        var o = GameObject.CreatePrimitive(t);
        var obj = GameObject.Instantiate(o, p, Quaternion.identity);
        obj.GetComponent<Collider>().enabled = false;
        obj.GetComponent<Renderer>().material.color = c;
        obj.transform.name = sign;
        obj.transform.localScale /= small;
    }
}
