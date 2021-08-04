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
        FindSwapablePoints();

    }
    private void OnMouseDrag()
    {
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
        adjustenedObjs = Physics2D.OverlapCircleAll(transform.position, 4);

    }

    //this works
    private void FindSwapablePoints()
    {
            //adds all available moveable locations

            AddAvailableTilesToMove(tilesData.currentMap, 1, 0, tilesData.availableMovesLoc);
            AddAvailableTilesToMove(tilesData.currentMap, -1, 0, tilesData.availableMovesLoc);
            AddAvailableTilesToMove(tilesData.currentMap, 0, 1, tilesData.availableMovesLoc);
            AddAvailableTilesToMove(tilesData.currentMap, 0, -1, tilesData.availableMovesLoc);

        //removes not symbiotic choices
        foreach(Vector2 vector in tilesData.availableMovesLoc)
        {
            Vector2Int currentVector = Vector2Int.CeilToInt(vector);
            //check by rows and collumns for pairs eg xxo or crossSections ej xox 
            CheckForAllAvailableMaches(currentVector);
        }
    }
    private void CheckForAllAvailableMaches(Vector2Int currentAvailableMoveVector)
    {
        //check by rows and collumns for pairs of two eg xxo
        //x check pos
        CheckIfMachingCollumnOrRowIsCreated(1, 0, 1, tilesData.currentMap, currentAvailableMoveVector);
        //x check neg
        CheckIfMachingCollumnOrRowIsCreated(1, 0, -1, tilesData.currentMap, currentAvailableMoveVector);
        //y check pos
        CheckIfMachingCollumnOrRowIsCreated(0, 1, 1, tilesData.currentMap, currentAvailableMoveVector);
        //y check neg
        CheckIfMachingCollumnOrRowIsCreated(0, 1, -1, tilesData.currentMap, currentAvailableMoveVector);

        //checks if a midsection is created ej xox by rows and collumns
        //x check
        MidPosCheckCollumnRow(1, 0, tilesData.currentMap, currentAvailableMoveVector);
        //y check
        MidPosCheckCollumnRow(0, 1, tilesData.currentMap, currentAvailableMoveVector);
    }
    private void CheckIfMachingCollumnOrRowIsCreated(int indexX,int indexY,int negativeOrPositve,BoxesData.TypeNPrefab[,] map,Vector2Int swapableCordsVector)
    {
        int offsetXCoord1= LimitAxes(swapableCordsVector.x + indexX * negativeOrPositve,true);
        int offsetYCoord1= LimitAxes(swapableCordsVector.y + indexY * negativeOrPositve,false);
        int offsetXCoord2 = LimitAxes(offsetXCoord1 + 1 * indexX * negativeOrPositve,true);
        int offsetYCoord2 = LimitAxes(offsetYCoord1 + 1 * indexY * negativeOrPositve,false);

        BoxesData.TypeNPrefab coord1Obj = map[offsetXCoord1, offsetYCoord1];
        BoxesData.TypeNPrefab coord2Obj = map[offsetXCoord2, offsetYCoord2];

        Vector2 coord1 = new Vector2(coord1Obj.x, coord1Obj.y);
        Vector2 coord2 = new Vector2(coord2Obj.x, coord2Obj.y);
        if (tilesData.locsOfSameTypeTiles.Contains(coord1) && tilesData.locsOfSameTypeTiles.Contains(coord2) && coord1 != coord2)
        {
            if (!tilesData.swapableLocs.Contains(swapableCordsVector))
            tilesData.swapableLocs.Add(swapableCordsVector);
        }

    }
    private void MidPosCheckCollumnRow(int indexX,int indexY, BoxesData.TypeNPrefab[,] map, Vector2Int swapableCordsVector)
    {
        int offsetXCoord1 =LimitAxes(swapableCordsVector.x + indexX ,true);
        int offsetYCoord1 =LimitAxes( swapableCordsVector.y + indexY,false) ;
        int offsetXCoord2 =LimitAxes( offsetXCoord1 -  indexX,true) ;
        int offsetYCoord2 =LimitAxes(offsetYCoord1 -  indexY,false) ;

        BoxesData.TypeNPrefab coord1Obj = map[offsetXCoord1, offsetYCoord1];
        BoxesData.TypeNPrefab coord2Obj = map[offsetXCoord2, offsetYCoord2];

        Vector2 coord1 = new Vector2(coord1Obj.x, coord1Obj.y);
        Vector2 coord2 = new Vector2(coord2Obj.x, coord2Obj.y);
        if (tilesData.locsOfSameTypeTiles.Contains(coord1) && tilesData.locsOfSameTypeTiles.Contains(coord2) && coord1 != coord2)
        {
            if (!tilesData.swapableLocs.Contains(swapableCordsVector))
                tilesData.swapableLocs.Add(swapableCordsVector);
        }

    }
    private int LimitAxes(int coordToLimit,bool horizontalAxes)
    {
        if (horizontalAxes)
        {
            return Mathf.Clamp(coordToLimit, 0, tilesData.parentSpawnBoxes.gameArray.x-1);
        }
        else
        {
            return Mathf.Clamp(coordToLimit, 0, tilesData.parentSpawnBoxes.gameArray.y-1);
        }
    }

    private void AddAvailableTilesToMove(BoxesData.TypeNPrefab[,] map, int indexX, int indexY,List<Vector2> swapableLocations)
    {
        int x = tilesData.thisType.x + indexX;
        int y = tilesData.thisType.y + indexY;

        int clampedX = Mathf.Clamp(x, 0, tilesData.parentSpawnBoxes.gameArray.x - 1);
        int clampedy = Mathf.Clamp(y, 0, tilesData.parentSpawnBoxes.gameArray.y - 1);

        BoxesData.TypeNPrefab currentTileToAdd = map[clampedX,clampedy];
        Vector2 coords = new Vector2(currentTileToAdd.x, currentTileToAdd.y);
        if (!swapableLocations.Contains(coords)&&!coords.Equals(tilesData.initialPos))
        swapableLocations.Add(coords);//pernei olles ths dinates thesis kai meta prepei na tsekaris gia na kseskartaris aftes mono

    }

    private void ResetSameFileTileList()
    {
        tilesData.locsOfSameTypeTiles.Clear();
        tilesData.availableMovesLoc.Clear();
        tilesData.swapableLocs.Clear();
    }
    private void OnDrawGizmos()
    {
        if (tilesData.debugLog)
        Gizmos.DrawWireSphere(transform.position, 2);
    }
}
