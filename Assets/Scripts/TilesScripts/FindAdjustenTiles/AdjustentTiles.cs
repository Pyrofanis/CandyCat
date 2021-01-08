using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustentTiles : MonoBehaviour
{
    private static Vector2[] castDir = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right }; 
    // Update is called once per frame
    void Update()
    {
        if(TileSelection.current.currentObject!=null&&TileSelection.next.currentObject!=null)
        CheckSelections();
    }
    private void CheckSelections()
    {
        if (!adjustentTilesL(TileSelection.current.currentObject).Contains(TileSelection.next))
        {
            TileSelection.next = new BoxesData.TypeNPrefab();
        }
    }
    public static List<BoxesData.TypeNPrefab> adjustentTilesL(GameObject gameObject)
    {
        List<BoxesData.TypeNPrefab> tiles = new List<BoxesData.TypeNPrefab>();
        foreach (Vector2 dir in castDir)
        {
            RaycastHit2D hit2D = Physics2D.Raycast(gameObject.transform.position, dir);
            if(hit2D.collider!=null)
            tiles.Add(hit2D.collider.GetComponent<TilesData>().tile);
        }
        return tiles;
    } 
}
