using System;
using UnityEngine;

public static class Utility
{
    public static Vector3[] ReadVerticesFromCSVText(string text)
    {
        var lines = text.Trim().Split('\n');
        var points = new Vector3[lines.Length];
        
        for (int i = 0; i < lines.Length; i++)
        {
            string[] strCoords = lines[i].Split(',');

            float x = 0.0f, y = 0.0f, z = 0.0f;
            float.TryParse(strCoords[0], out x);
            float.TryParse(strCoords[1], out y);
            float.TryParse(strCoords[2], out z);

            points[i] = new Vector3(x, y, z);
        }

        return points;
    }      

    public static GameObject InstantiatePointGO(Vector3 position, Material material)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position; // World Position
        sphere.transform.localScale = Vector3.one * 0.05f;
        sphere.GetComponent<MeshRenderer>().material = new Material(material);

        return sphere;
    }

    public static GameObject[] InstantiatePointGOs(Vector3[] points, Material material, Transform parent = null)
    {
        GameObject[] spheres = new GameObject[points.Length];

        for (int i = 0; i < points.Length; i++)
        {
            spheres[i] = InstantiatePointGO(points[i], material);
            if (parent != null)
                spheres[i].transform.parent = parent;
        }
        return spheres;
    }

    public static Vector3 GetNormal(Vector3 a, Vector3 b, Vector3 c)
    {
        Vector3 side1 = b - a;
        Vector3 side2 = c - a;
        return Vector3.Cross(side1, side2).normalized;
    }

    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = point - pivot;
        dir = Quaternion.Euler(angles) * dir;
        point = dir + pivot;

        return point;
    }
}

