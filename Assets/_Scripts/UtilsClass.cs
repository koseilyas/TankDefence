
using System;
using UnityEngine;

public static class UtilsClass
{
    public static Vector3 SnapToTile(this Vector3 vector3, float gridSize = 1.0f)
    {
        float x = vector3.x;
        GetNearestHalf(ref x);

        float y = Mathf.Round(vector3.y / gridSize) * gridSize;
        float z = Mathf.Round(vector3.z / gridSize) * gridSize;

        if (x < GridContainer.Instance.leftMost)
            x = GridContainer.Instance.leftMost;
        if (x > GridContainer.Instance.rightMost)
            x = GridContainer.Instance.rightMost;
        if (y < GridContainer.Instance.downMost)
            y = GridContainer.Instance.downMost;
        if (y > GridContainer.Instance.upMost)
            y = GridContainer.Instance.upMost;
        return new Vector3(x, y, z);
    }
    
    public static Vector3 Snap(this Vector3 vector3, float gridSize = 1.0f)
    {
        return new Vector3(
            Mathf.Round(vector3.x  / gridSize) * gridSize,
            Mathf.Round(vector3.y / gridSize) * gridSize,
            Mathf.Round(vector3.z / gridSize) * gridSize);
    }

    private static void GetNearestHalf(ref float number)
    {
        var y = Mathf.Round(number-0.5f);
        number = y + .5f;
    }
}
