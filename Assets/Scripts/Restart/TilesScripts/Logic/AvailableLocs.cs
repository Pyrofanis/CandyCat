using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableLocs : MonoBehaviour
{
    private TilesData tilesData;
    private Collider2D[] adjustenedObjs;
    // Start is called before the first frame update
    void Start()
    {
        tilesData = GetComponent<TilesData>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnMouseEnter()
    {
        GetNearObjs();
        FindSameTypeTiles();

    }
    private void OnMouseDrag()
    {
        FindSwapablePoints();
    }
    private void OnMouseUp()
    {
        ResetSameFileTileList();
    }
    private void FindSameTypeTiles()
    {
        foreach (Collider2D collider in adjustenedObjs)
        {
            BoxesData.TypeNPrefab currentType = collider.GetComponent<TilesData>().thisType;
            Vector2 coords = new Vector2(currentType.x, currentType.y);
            if (currentType.boxType.Equals(tilesData.thisType.boxType)&&!tilesData.locsOfSameTypeTiles.Contains(coords))
            {
                tilesData.locsOfSameTypeTiles.Add(coords);
            }
        }
    }
    private void GetNearObjs()
    {
        adjustenedObjs = Physics2D.OverlapCircleAll(transform.position, 2);

    }
    private void FindSwapablePoints()
    {
        for (int i = 0; i < tilesData.locsOfSameTypeTiles.Count; i++)
        {
            CheckIfEqual(tilesData.currentMap, 1, 0, tilesData.SwapableLocs);
            CheckIfEqual(tilesData.currentMap, -1, 0, tilesData.SwapableLocs);
            CheckIfEqual(tilesData.currentMap, 0, 1, tilesData.SwapableLocs);
            CheckIfEqual(tilesData.currentMap, 0, -1, tilesData.SwapableLocs);
        }
    }
    private void CheckIfEqual(BoxesData.TypeNPrefab[,] map, int indexX, int indexY,List<Vector2> swapableLocations)
    {
        BoxesData.TypeNPrefab currentTileToAdd = map[tilesData.thisType.x + indexX, tilesData.thisType.y + indexY];
        Vector2 coords = new Vector2(currentTileToAdd.x, currentTileToAdd.y);
        if (!swapableLocations.Contains(coords))
        swapableLocations.Add(coords);//pernei olles ths dinates thesis kai meta prepei na tsekaris gia na kseskartaris aftes mono

    }

    private void ResetSameFileTileList()
    {
        //tilesData.locsOfSameTypeTiles.Clear();
        //tilesData.SwapableLocs.Clear();
    }
    private void OnDrawGizmos()
    {
        if (tilesData.debugLog)
        Gizmos.DrawWireSphere(transform.position, 2);
    }
}
