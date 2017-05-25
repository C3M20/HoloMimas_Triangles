using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    //Grid variables
    public int Rows;
    public int Columns;
    public int Slices;

    //Forumla variables
    public int InterSliceDistnace;
    public int SpacingAlongX;
    public int SpacingAlongY;
    public Vector3 Xxyz;
    public Vector3 Yxyz;
    public Vector3 Zxyz;
    public Vector3 Sxyz;

    //public int SpacingAlongz; 

	// Use this for initialization
	void Start () {
        DrawRow();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void DrawRow()
    {        
        int size = 6 * Rows * Columns * Slices; 
        Vector3[] verts = new Vector3[size];
        Vector2[] uvs = new Vector2[size];
        int[] triangs = new int[size];
        Color[] colors = new Color[size];
        int idx = 0;

        for (int k = 0; k < Slices; k++)
        {           
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {

                    verts[idx] = getRCSPixel(i, j, k);
                    verts[idx + 1] = getRCSPixel(i + 1, j, k);
                    verts[idx + 2] = getRCSPixel(i + 1, j + 1, k);
                    verts[idx + 3] = getRCSPixel(i + 1, j + 1, k);
                    verts[idx + 4] = getRCSPixel(i, j + 1, k);
                    verts[idx + 5] = getRCSPixel(i, j, k);


                    //verts[idx] = new Vector3(i, j, k);
                    //verts[idx + 1] = new Vector3(i + 1, j, k);
                    //verts[idx + 2] = new Vector3(i + 1, j + 1, k);
                    //verts[idx + 3] = new Vector3(i + 1, j + 1, k);
                    //verts[idx + 4] = new Vector3(i, j + 1, k);
                    //verts[idx + 5] = new Vector3(i, j, k);

                    //Debug.Log(verts[idx]);
                    //Debug.Log(verts[idx + 1]);
                    //Debug.Log(verts[idx + 2]);
                    //Debug.Log(verts[idx + 3]);
                    //Debug.Log(verts[idx + 4]);
                    //Debug.Log(verts[idx + 5]);

                    uvs[idx] = new Vector2(verts[idx].x, verts[idx].z);
                    uvs[idx + 1] = new Vector2(verts[idx + 1].x, verts[idx + 1].z);
                    uvs[idx + 2] = new Vector2(verts[idx + 2].x, verts[idx + 2].z);
                    uvs[idx + 3] = new Vector2(verts[idx + 3].x, verts[idx + 3].z);
                    uvs[idx + 4] = new Vector2(verts[idx + 4].x, verts[idx + 4].z);
                    uvs[idx + 5] = new Vector2(verts[idx + 5].x, verts[idx + 5].z);

                    triangs[idx] = idx;
                    triangs[idx + 1] = idx + 1;
                    triangs[idx + 2] = idx + 2;
                    triangs[idx + 3] = idx + 3;
                    triangs[idx + 4] = idx + 4;
                    triangs[idx + 5] = idx + 5;

                    //colors[idx] = Color.red;
                    //colors[idx + 1] = Color.green;
                    //colors[idx + 2] = Color.blue;
                    //colors[idx + 3] = Color.red;
                    //colors[idx + 4] = Color.green;
                    //colors[idx + 5] = Color.blue;

                    idx += 6;
                }
            }
        }

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = verts;
        mesh.uv = uvs;
        mesh.triangles = triangs;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        //mesh.colors = colors;
    }

    Vector3 getRCSPixel(int i, int j, int k)
    {
        float Px = 0f,Py=0f, Pz=0f; 
        Px = Xxyz.x * SpacingAlongX * i + Yxyz.x * SpacingAlongY * j + Zxyz.x * InterSliceDistnace * k + Sxyz.x;
        Py = Xxyz.y * SpacingAlongX * i + Yxyz.y * SpacingAlongY * j + Zxyz.y * InterSliceDistnace * k + Sxyz.y;
        Pz = Xxyz.z * SpacingAlongX * i + Yxyz.z * SpacingAlongY * j + Zxyz.z * InterSliceDistnace * k + Sxyz.z;

        return new Vector3(Px, Py, Pz);
    }

    void DrawSimpleSquare()
    {
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
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = verts;
        mesh.uv = uvs;
        mesh.triangles = triangs;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}

