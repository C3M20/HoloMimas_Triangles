using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class takes the vertices from the user and creates one triangle
//The color of the triangles is applied depending on its position. The greates x is red the greatest y is green and greatest z is blue
//If there is only a triangle in two axis then is only two colors
public class Triangle : MonoBehaviour {

    public Vector3 vert1;
    public Vector3 vert2;
    public Vector3 vert3;

    // Use this for initialization
    void Start () {
        DrawTriangle(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DrawTriangle()
    {
        Vector3[] verts = new Vector3[3];
        verts[0] = vert1; // new Vector3(0f, 0f, 0f);
        verts[1] = vert3; //new Vector3(10f, 10f, 10f);
        verts[2] = vert2; //new Vector3(10f, 10f, 0f);

        Vector2[] uvs = new Vector2[3];
        uvs[0] = new Vector2(verts[0].x, verts[0].z);
        uvs[1] = new Vector2(verts[1].x, verts[1].z);
        uvs[2] = new Vector2(verts[2].x, verts[2].z);

        int[] triangs = new int[3];
        triangs[0] = 0;
        triangs[1] = 1;
        triangs[2] = 2;

        Color[] colors = colorChooser();
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = verts;
        mesh.uv = uvs;
        mesh.triangles = triangs;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.colors = colors;

    }

    Color[] colorChooser()
    {
        Color[] colors = new Color[3];

        //If there is only two axis
        if (vert1.x == 0 && vert2.x == 0 && vert3.x == 0)
            colors = twoColorX(Color.blue, Color.green, colors);
        else if (vert1.y == 0 && vert2.y == 0 && vert3.y == 0)
            colors = twoColorY(Color.blue, Color.red, colors);
        else if (vert1.z == 0 && vert2.z == 0 && vert3.z == 0)
            colors = twoColorZ(Color.red, Color.green, colors);

        //Therea are more than two axis 
        else
        {
            colors = threeColor(colors); // different values per vector 
        }

        return colors;
    }

    //Select each vertices
    Color selectVert1Color()
    {
        if (vert1.x > vert2.x && vert1.x > vert3.x)
            return Color.red;
        else if (vert1.y > vert2.y && vert1.y > vert3.y)
            return Color.green;
        else if (vert1.z > vert2.z && vert1.z > vert3.z)
            return Color.blue;
        else
            return Color.white;
    }
    Color selectVert2Color()
    {
        if (vert2.x > vert1.x && vert2.x > vert3.x)
            return Color.red;
        else if (vert2.y > vert1.y && vert2.y > vert3.y)
            return Color.green;
        else if (vert2.z > vert1.z && vert2.z > vert3.z)
            return Color.blue;
        else
            return Color.white;
    }
    Color selectVert3Color()
    {
        if (vert3.x > vert1.x && vert3.x > vert2.x)
            return Color.red;
        else if (vert3.y > vert1.y && vert3.y > vert2.y)
            return Color.green;
        else if (vert3.z > vert1.z && vert3.z > vert2.z)
            return Color.blue;
        else
            return Color.white;
    }

    //When one of the vertices are in the center 
    Color[] twoColorZ(Color repeatedColor, Color otherColor, Color[] color)
    {
        //Vertice1 is in the center
        if (vert1.x == 0 && vert1.y == 0 && vert1.z == 0)
        {
            if (Mathf.Abs(vert2.x) > Mathf.Abs(vert3.x))
            {
                color[0] = repeatedColor;
                color[1] = otherColor;
                color[2] = repeatedColor;
            }
            else
            {
                color[0] = repeatedColor;
                color[1] = repeatedColor;
                color[2] = otherColor;
            }
        }

        else if (vert2.x == 0 && vert2.y == 0 && vert2.z == 0)
        {
            if (Mathf.Abs(vert1.x) > Mathf.Abs(vert3.x))
            {
                color[0] = repeatedColor;
                color[1] = otherColor;
                color[2] = repeatedColor;
            }
            else
            {
                color[0] = otherColor;
                color[1] = repeatedColor;
                color[2] = repeatedColor;
            }

        }
        else if (vert3.x == 0 && vert3.y == 0 && vert3.z == 0)
        {
            if (Mathf.Abs(vert1.x) > Mathf.Abs(vert2.x))
            {
                color[0] = repeatedColor;
                color[1] = repeatedColor;
                color[2] = otherColor;
            }
            else
            {
                color[0] = otherColor;
                color[1] = repeatedColor;
                color[2] = repeatedColor;
            }

        }
        return color;
    }
    Color[] twoColorX(Color repeatedColor, Color otherColor, Color[] color)
    {
        //Vertice1 is in the center
        if (vert1.x == 0 && vert1.y == 0 && vert1.z == 0)
        {

            if (Mathf.Abs(vert2.y) > Mathf.Abs(vert3.y))
            {
                color[0] = repeatedColor;
                color[1] = otherColor;
                color[2] = repeatedColor;
            }
            else
            {
                color[0] = repeatedColor;
                color[1] = repeatedColor;
                color[2] = otherColor;
            }
        }

        else if (vert2.x == 0 && vert2.y == 0 && vert2.z == 0)
        {
            if (Mathf.Abs(vert1.y) < Mathf.Abs(vert3.y))
            {
                color[0] = repeatedColor;
                color[1] = otherColor;
                color[2] = repeatedColor;
            }
            else
            {
                color[0] = otherColor;
                color[1] = repeatedColor;
                color[2] = repeatedColor;
            }

        }
        else if (vert3.x == 0 && vert3.y == 0 && vert3.z == 0)
        {
            if (Mathf.Abs(vert1.y) < Mathf.Abs(vert2.y))
            {
                color[0] = repeatedColor;
                color[1] = repeatedColor;
                color[2] = otherColor;
            }
            else
            {
                color[0] = otherColor;
                color[1] = repeatedColor;
                color[2] = repeatedColor;
            }

        }
        return color;
    }
    Color[] twoColorY(Color repeatedColor, Color otherColor, Color[] color)
    {
        //Vertice1 is in the center
        if (vert1.x == 0 && vert1.y == 0 && vert1.z == 0)
        {
            if (Mathf.Abs(vert2.z) > Mathf.Abs(vert3.z))
            {
                color[0] = repeatedColor;
                color[1] = otherColor;
                color[2] = repeatedColor;
            }
            else
            {
                color[0] = repeatedColor;
                color[1] = repeatedColor;
                color[2] = otherColor;
            }
        }

        else if (vert2.x == 0 && vert2.y == 0 && vert2.z == 0)
        {
            if (Mathf.Abs(vert1.z) > Mathf.Abs(vert3.z))
            {
                color[0] = repeatedColor;
                color[1] = otherColor;
                color[2] = repeatedColor;
            }
            else
            {
                color[0] = otherColor;
                color[1] = repeatedColor;
                color[2] = repeatedColor;
            }

        }
        else if (vert3.x == 0 && vert3.y == 0 && vert3.z == 0)
        {
            if (Mathf.Abs(vert1.z) > Mathf.Abs(vert2.z))
            {
                color[0] = repeatedColor;
                color[1] = repeatedColor;
                color[2] = otherColor;
            }
            else
            {
                color[0] = otherColor;
                color[1] = repeatedColor;
                color[2] = repeatedColor;
            }

        }
        return color;
    }

    //three color
    Color[] threeColor(Color[] color)
    {
        bool vert1R = false;
        bool vert1B = false;
        bool vert1G = false;

        bool vert2R = false;
        bool vert2B = false;
        bool vert2G = false;

        bool vert3R = false;
        bool vert3B = false;
        bool vert3G = false;

        // x is the greater value of the vector
        if (Mathf.Abs(vert1.x) > Mathf.Abs(vert1.y) && Mathf.Abs(vert1.x) > Mathf.Abs(vert1.z))
            vert1R = true;
        if (Mathf.Abs(vert2.x) > Mathf.Abs(vert2.y) && Mathf.Abs(vert2.x) > Mathf.Abs(vert2.z))
            vert2R = true;
        if (Mathf.Abs(vert3.x) > Mathf.Abs(vert3.y) && Mathf.Abs(vert3.x) > Mathf.Abs(vert3.z))
            vert3R = true;

        // y is the greater value of the vector
        if (Mathf.Abs(vert1.y) > Mathf.Abs(vert1.x) && Mathf.Abs(vert1.y) > Mathf.Abs(vert1.z))
            vert1G = true;
        if (Mathf.Abs(vert2.y) > Mathf.Abs(vert2.x) && Mathf.Abs(vert2.y) > Mathf.Abs(vert2.z))
            vert2G = true;
        if (Mathf.Abs(vert3.y) > Mathf.Abs(vert3.x) && Mathf.Abs(vert3.y) > Mathf.Abs(vert3.z))
            vert3G = true;

        // z is the greater value of the vector
        if (Mathf.Abs(vert1.z) > Mathf.Abs(vert1.x) && Mathf.Abs(vert1.z) > Mathf.Abs(vert1.y))
            vert1B = true;
        if (Mathf.Abs(vert2.z) > Mathf.Abs(vert2.x) && Mathf.Abs(vert2.z) > Mathf.Abs(vert2.y))
            vert2B = true;
        if (Mathf.Abs(vert3.z) > Mathf.Abs(vert3.x) && Mathf.Abs(vert3.z) > Mathf.Abs(vert3.y))
            vert3B = true;

        //Color splitter 
        //If all of the vector are high in red
        if (vert1R && vert2R && vert3R)
        {
            if (Mathf.Abs(vert1.x) > Mathf.Abs(vert2.x) && Mathf.Abs(vert1.x) > Mathf.Abs(vert3.x))
                color[0] = Color.red;
            else if (Mathf.Abs(vert2.x) > Mathf.Abs(vert1.x) && Mathf.Abs(vert2.x) > Mathf.Abs(vert3.x))
                color[2] = Color.red;
            else
                color[1] = Color.red;
        }

        //If not all are high in red
        if (vert1R && !vert2R && !vert3R)
            color[0] = Color.red;
        else if (!vert1R && vert2R && !vert3R)
            color[2] = Color.red;
        else if (!vert1R && !vert2R && vert3R)
            color[1] = Color.red;


        //If all of the vector are high in green
        if (vert1G && vert2G && vert3G)
        {
            if (Mathf.Abs(vert1.y) > Mathf.Abs(vert2.y) && Mathf.Abs(vert1.y) > Mathf.Abs(vert3.y))
                color[0] = Color.green;
            else if (Mathf.Abs(vert2.y) > Mathf.Abs(vert1.y) && Mathf.Abs(vert2.y) > Mathf.Abs(vert3.y))
                color[2] = Color.green;
            else
                color[1] = Color.green;
        }

        //If not all are high in green
        if (vert1G && !vert2G && !vert3G)
            color[0] = Color.green;
        else if (!vert1G && vert2G && !vert3G)
            color[2] = Color.green;
        else if (!vert1G && !vert2G && vert3G)
            color[1] = Color.green;

        //If all of the vector are high in blue
        if (vert1B && vert2B && vert3B)
        {
            if (Mathf.Abs(vert1.z) > Mathf.Abs(vert2.z) && Mathf.Abs(vert1.z) > Mathf.Abs(vert3.z))
                color[0] = Color.blue;
            else if (Mathf.Abs(vert2.z) > Mathf.Abs(vert1.z) && Mathf.Abs(vert2.z) > Mathf.Abs(vert3.z))
                color[2] = Color.blue;
            else
                color[1] = Color.blue;
        }

        //If not all are high in blue
        if (vert1B && !vert2B && !vert3B)
            color[0] = Color.blue;
        else if (!vert1B && vert2B && !vert3B)
            color[2] = Color.blue;
        else if (!vert1B && !vert2B && vert3B)
            color[1] = Color.blue;

        //When two vertices have the same value 

        //Red Value
        if (!vert1R && !vert2R && !vert3R && !vert1G && !vert1B)
        {
            color[0] = Color.red;
            vert1R = true;
        }
        if (!vert1R && !vert2R && !vert3R && !vert2G && !vert2B)
            color[2] = Color.red;
        if (!vert1R && !vert2R && !vert3R && !vert3G && !vert3B)
            color[1] = Color.red;


        //Blue Value
        if (!vert1B && !vert2B && !vert3B && !vert1R && !vert1G)
        {
            color[0] = Color.blue;
            vert1B = true;
        }
        if (!vert1B && !vert2B && !vert3B && !vert2R && !vert2G)
            color[2] = Color.blue;
        if (!vert1B && !vert2B && !vert3B && !vert3R && !vert3G)
            color[1] = Color.blue;



        //Green Value
        if (!vert1G && !vert2G && !vert3G && !vert1R && !vert1B) //
        {
            color[0] = Color.green;
            vert1G = false;
        }
        if (!vert1G && !vert2G && !vert3G && !vert2R && !vert2B)//
            color[2] = Color.green;
        if (!vert1G && !vert2G && !vert3G && !vert3R && !vert3B)
            color[1] = Color.green;


        //When Two Red columns 
        if (!vert1R && !vert2R && !vert3R)
        {
            if ((vert1B && vert2B) || (vert1B && vert3B) || (vert3B && vert2B))
                color = finalSetUp(Color.blue, Color.green, color);
            else if ((vert1G && vert2G) || (vert1G && vert3G) || (vert3G && vert2G))
                color = finalSetUp(Color.green, Color.blue, color);
        }
        else if (!vert1G && !vert2G && !vert3G)
        {
            if ((vert1R && vert2R) || (vert1R && vert3R) || (vert3R && vert2R))
                color = finalSetUp(Color.red, Color.blue, color);
            else if ((vert1B && vert2B) || (vert1B && vert3B) || (vert3B && vert2B))
                color = finalSetUp(Color.blue, Color.red, color);
        }
        else //(vert1B)
        {
            if ((vert1R && vert2R) || (vert1R && vert3R) || (vert3R && vert2R))
                color = finalSetUp(Color.red, Color.green, color);
            else if ((vert1G && vert2G) || (vert1G && vert3G) || (vert3G && vert2G))
                color = finalSetUp(Color.green, Color.red, color);
        }
        return color;
    }

    Color[] finalSetUp(Color repeated, Color compareColor, Color[] color)
    {
        if (color[0] == compareColor)
        {
            color[1] = repeated;
            color[2] = repeated;
        }
        else if (color[1] == compareColor)
        {
            color[0] = repeated;
            color[2] = repeated;
        }
        else
        {
            color[0] = repeated;
            color[1] = repeated;
        }
        return color;
    }
}
