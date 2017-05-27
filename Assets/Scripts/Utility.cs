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

    public static int[,,] ReadColorsFromText(string text, int slices, int rows, int columns)
    {
        var lines = text.Trim().Split('\n');
        int[,,] colors = new int[slices, rows, columns];

        Debug.Log("S: " + slices + " R: " + rows + " C:" + columns);
        Debug.Log(lines.Length);

        for (int i = 0; i < lines.Length; i++) 
        {
            string[] strCoords = lines[i].Split(',');

            int x = 0, y = 0, z = 0, colorValue;
            int.TryParse(strCoords[0], out z);
            int.TryParse(strCoords[1], out y);
            int.TryParse(strCoords[2], out x);
            int.TryParse(strCoords[3], out colorValue);

            colors[z, y, x] = MapRange(colorValue, 0, 800, 0, 255); //Change the rangle from 0 to 800 -> 0 to 255 
            //Debug.Log("z: "+z+" y: "+y+" x: "+x+" c:"+colors[z, y, x]);
        }
        return colors;
    }

    public static int MapRange(int value, int inlow, int inhigh, int outlow, int outhigh){
        return (value - inlow) * (outhigh - outlow) / (inhigh - inlow) + outlow;
         
    }

    public static Vector4[] ReadColorsFromTextRV(string text)
    {
        var lines = text.Trim().Split('\n');
        var points = new Vector4[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            string[] strCoords = lines[i].Split(',');

            int x = 0, y = 0, z = 0, colorValue;
            int.TryParse(strCoords[0], out x);
            int.TryParse(strCoords[1], out y);
            int.TryParse(strCoords[2], out z);
            int.TryParse(strCoords[3], out colorValue);

            points[i] = new Vector4(x, y, z, MapRange(colorValue, 0, 800, 0, 255));
        }

        return points;
    }

   
}

