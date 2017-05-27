using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO : tried to combine meshes and see if it optimize 
public class CombineMeshes : MonoBehaviour {

    Mesh mesh;
   public GameObject obj1;

    // Use this for initialization
    void Start()
    {  
        
        Triangle1();
        Triangle2();

 
    }
    // Update is called once per frame
    void Update () {
		
	}

    void Triangle1 (Transform parent = null)
    {
        GameObject test = Instantiate(obj1); 
        Vector3[] verts = new Vector3[6];
        verts[0] = new Vector3(0f, 0f, 0f);
        verts[1] = new Vector3(0f, 1f, 0f);
        verts[2] = new Vector3(1f, 1f, 0f);
        verts[3] = new Vector3(1f, 1f, 0f);
        verts[4] = new Vector3(1f, 0f, 0f);
        verts[5] = new Vector3(0f, 0f, 0f);


        Vector2[] uvs = new Vector2[6];
        uvs[0] = new Vector2(verts[0].x, verts[0].z);
        uvs[1] = new Vector2(verts[1].x, verts[1].z);
        uvs[2] = new Vector2(verts[2].x, verts[2].z);
        uvs[3] = new Vector2(verts[3].x, verts[3].z);
        uvs[4] = new Vector2(verts[4].x, verts[4].z);
        uvs[5] = new Vector2(verts[5].x, verts[5].z);

        int[] triangs = new int[6];
        triangs[0] = 0;
        triangs[1] = 1;
        triangs[2] = 2;
        triangs[3] = 3;
        triangs[4] = 4;
        triangs[5] = 5;

        Mesh mesh = new Mesh();
        test.GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = verts;
        mesh.uv = uvs;
        mesh.triangles = triangs;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        test.transform.SetParent(obj1.transform.parent);


    }
    void Triangle2(Transform parent = null)
    {
        GameObject test = Instantiate(obj1);
        Vector3[] verts = new Vector3[6];
        verts[0] = new Vector3(0f, 0f, 1f);
        verts[1] = new Vector3(0f, 1f, 1f);
        verts[2] = new Vector3(1f, 1f, 1f);
        verts[3] = new Vector3(1f, 1f, 1f);
        verts[4] = new Vector3(1f, 0f, 1f);
        verts[5] = new Vector3(0f, 0f, 1f);


        Vector2[] uvs = new Vector2[6];
        uvs[0] = new Vector2(verts[0].x, verts[0].z);
        uvs[1] = new Vector2(verts[1].x, verts[1].z);
        uvs[2] = new Vector2(verts[2].x, verts[2].z);
        uvs[3] = new Vector2(verts[3].x, verts[3].z);
        uvs[4] = new Vector2(verts[4].x, verts[4].z);
        uvs[5] = new Vector2(verts[5].x, verts[5].z);

        int[] triangs = new int[6];
        triangs[0] = 0;
        triangs[1] = 1;
        triangs[2] = 2;
        triangs[3] = 3;
        triangs[4] = 4;
        triangs[5] = 5;

        Mesh mesh = new Mesh();
       test.GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = verts;
        mesh.uv = uvs;
        mesh.triangles = triangs;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        test.transform.SetParent(obj1.transform.parent);


    }

}

