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
            //adds all available moveable locations
            AddAvailableTilesToMove(tilesData.currentMap, 1, 0, tilesData.SwapableLocs);
            AddAvailableTilesToMove(tilesData.currentMap, -1, 0, tilesData.SwapableLocs);
            AddAvailableTilesToMove(tilesData.currentMap, 0, 1, tilesData.SwapableLocs);
            AddAvailableTilesToMove(tilesData.currentMap, 0, -1, tilesData.SwapableLocs);
        //removes not symbiotic choices
        foreach(Vector2 vector in tilesData.SwapableLocs)
        {
            Vector2Int currentVector = Vector2Int.CeilToInt(vector);
            //check by rows and collumns for pairs of two and removes if not eg xxo
            //x check pos
            CheckIfMachingCollumnOrRowIsCreated(1, 0, 1, tilesData.currentMap, currentVector);
            //x check neg
            CheckIfMachingCollumnOrRowIsCreated(1, 0, -1, tilesData.currentMap, currentVector);
            //y check pos
            CheckIfMachingCollumnOrRowIsCreated(0, 1, 1, tilesData.currentMap, currentVector);
            //y check neg
            CheckIfMachingCollumnOrRowIsCreated(0, 1, -1, tilesData.currentMap, currentVector);
            //checks if a midsection is created ej xox by rows and collumns
            //x check
            MidPosCheckCollumnRow(1, 0, tilesData.currentMap, currentVector);
            //y check
            MidPosCheckCollumnRow(0, 1, tilesData.currentMap, currentVector);
        }
    }
    private void CheckIfMachingCollumnOrRowIsCreated(int indexX,int indexY,int negativeOrPositve,BoxesData.TypeNPrefab[,] map,Vector2Int swapableCordsVector)
    {
        int offsetXCoord1= swapableCordsVector.x + indexX * negativeOrPositve;
        int offsetYCoord1= swapableCordsVector.y + indexY * negativeOrPositve;
        BoxesData.TypeNPrefab coord1Obj=map[offsetXCoord1, offsetYCoord1];
        int offsetXCoord2=offsetXCoord1+1*indexX*negativeOrPositve;
        int offsetYCoord2= offsetYCoord1 + 1 * indexY * negativeOrPositve;
        BoxesData.TypeNPrefab coord2Obj= map[offsetXCoord2,offsetYCoord2];

        Vector2 coord1 = new Vector2(coord1Obj.x, coord1Obj.y);
        Vector2 coord2 = new Vector2(coord2Obj.x, coord2Obj.y);
        if (!tilesData.locsOfSameTypeTiles.Contains(coord1)|| !tilesData.locsOfSameTypeTiles.Contains(coord2))
        {
            tilesData.SwapableLocs.Remove(swapableCordsVector);
            tilesData.SwapableLocs.TrimExcess();
        }
        
    }
    private void MidPosCheckCollumnRow(int indexX,int indexY, BoxesData.TypeNPrefab[,] map, Vector2Int swapableCordsVector)
    {
        int offsetXCoord1 = swapableCordsVector.x + indexX ;
        int offsetYCoord1 = swapableCordsVector.y + indexY ;
        BoxesData.TypeNPrefab coord1Obj = map[offsetXCoord1, offsetYCoord1];
        int offsetXCoord2 = offsetXCoord1 -  indexX ;
        int offsetYCoord2 = offsetYCoord1 -  indexY ;
        BoxesData.TypeNPrefab coord2Obj = map[offsetXCoord2, offsetYCoord2];
        Vector2 coord1 = new Vector2(coord1Obj.x, coord1Obj.y);
        Vector2 coord2 = new Vector2(coord2Obj.x, coord2Obj.y);
        if (!tilesData.locsOfSameTypeTiles.Contains(coord1) || !tilesData.locsOfSameTypeTiles.Contains(coord2))
        {
            tilesData.SwapableLocs.Remove(swapableCordsVector);
            tilesData.SwapableLocs.TrimExcess();
        }

    }

    private void AddAvailableTilesToMove(BoxesData.TypeNPrefab[,] map, int indexX, int indexY,List<Vector2> swapableLocations)
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
