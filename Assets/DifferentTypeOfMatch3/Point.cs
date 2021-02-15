using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Point
{
    int x, y;
    public Point(int _NewX, int _NewY)
    {
        x = _NewX;
        y = _NewY;
    }
    public void Multiply(int multiplier)
    {
        x *= multiplier;
        y *= multiplier;
    }
    public void Addition(Point _OtherPoint)
    {
        x += _OtherPoint.x;
        y += _OtherPoint.y;
    }
    public Vector2 ToVector()
    {
        return new Vector2(x, y);
    }
    public bool Equals(Point _CurrentPoint)
    {
        return (x == _CurrentPoint.x && y == _CurrentPoint.y);
    }
    public static Point FromVector(Vector2 vector2)
    {
        return new Point((int)vector2.x, (int)vector2.y);
    }
    public static Point FromVector3(Vector3 vector2)
    {
        return new Point((int)vector2.x, (int)vector2.y);
    }
    public static Point Multiply(Point _CurrentPoint, int multiplier)
    {
        return new Point(_CurrentPoint.x * multiplier, _CurrentPoint.y * multiplier);
    }
    public static Point Addition(Point _CurrentPoint, Point _OtherPoint)
    {
        return new Point(_CurrentPoint.x + _OtherPoint.x, _CurrentPoint.y + _OtherPoint.y);
    }
    public static Point Zero
    {
        get { return new Point(0, 0); }
    }
    public static Point One
    {
        get { return new Point(1, 1); }
    }
    public static Point Up
    {
        get { return new Point(0, 1); }
    }
    public static Point Down
    {
        get { return new Point(0, -1); }
    }
    public static Point Left
    {
        get { return new Point(-1, 0); }
    }
    public static Point Rigt
    {
        get { return new Point(1, 0); }
    }
}
