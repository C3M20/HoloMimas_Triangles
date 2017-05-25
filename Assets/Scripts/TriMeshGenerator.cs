using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriMeshGenerator : MonoBehaviour {

    TextAsset Vert;
    Vector3[] triangleVert;

    // Use this for initialization
    void Start () {
        Vert = Resources.Load("triangle_data") as TextAsset;
        triangleVert = Utility.ReadVerticesFromCSVText(Vert.text);;
        CreateMesh(); 
    }

    // Update is called once per frame
    void Update () {
		
	}

    void CreateMesh()
    {
        int size = triangleVert.Length;
        Vector3[] verts = new Vector3[size];
        Vector2[] uvs = new Vector2[size];
        int[] triangs = new int[size];
        Color[] colors = new Color[size];

        for (int i = 0; i < triangleVert.Length; i+=3)
        {           
            verts[i] = triangleVert[i]; 
            verts[i+1] = triangleVert[i+1]; 
            verts[i+2] = triangleVert[i+2]; 
                        
            uvs[i] = new Vector2(verts[i].x, verts[i].z);
            uvs[i + 1] = new Vector2(verts[i + 1].x, verts[i + 1].z);
            uvs[i + 2] = new Vector2(verts[i + 2].x, verts[i + 2].z);
                       
            triangs[i] = i;
            triangs[i + 1] = i+1;
            triangs[i + 2] = i+2;
                        
            colors[i] = Color.red;
            colors[i + 1] = Color.green;
            colors[i + 2] = Color.blue;
        }
       
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = verts;
        mesh.uv = uvs;
        mesh.triangles = triangs;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.colors = colors;
    }

    public Vector3[] getriangleVert()
    {
        return triangleVert;
    }


}
