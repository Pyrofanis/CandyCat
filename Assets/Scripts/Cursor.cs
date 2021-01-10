using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public static Vector3 MousePosition()
    {
        Vector3 mousePixelPos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePixelPos);
        return mouseWorldPos;
    }
}
