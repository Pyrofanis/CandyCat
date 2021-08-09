using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTiles : MonoBehaviour
{
    public static void ResetTilesColider()
    {
        foreach(BoxesData.TypeNPrefab type in SpawnBoxes.arrayList)
        {
            type.currentObject.GetComponent<Collider2D>().enabled = true;
        }
    }
    public static void ResetSelections()
    {
       TileSelection.current = new BoxesData.TypeNPrefab();
       TileSelection.next = new BoxesData.TypeNPrefab();
    }
}
