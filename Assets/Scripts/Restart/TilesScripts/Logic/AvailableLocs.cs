using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableLocs : MonoBehaviour
{
    private TilesData tilesData;

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
        foreach (BoxesData.TypeNPrefab typeNPrefab in tilesData.currentMap)
        {
            Vector2 coords = new Vector2(typeNPrefab.x, typeNPrefab.y);
            if (typeNPrefab.boxType.Equals(tilesData.thisType.boxType)&&!tilesData.locsOfSameTypeTiles.Contains(coords))
            {
                tilesData.locsOfSameTypeTiles.Add(coords);
            }
        }
    }
    private void FindSwapablePoints()
    {
        for (int i = 0; i < tilesData.locsOfSameTypeTiles.Count; i++)
        {
            Vector2 currentVecor=tilesData.locsOfSameTypeTiles[i];
            Check(currentVecor, 0, 0, tilesData.locsOfSameTypeTiles, tilesData.SwapableLocs,1);
            Check(currentVecor, 0, 0, tilesData.locsOfSameTypeTiles, tilesData.SwapableLocs,-1);
        }
    }
    private void Check(Vector2 vector ,int indexX,int indexY,List<Vector2> listToCheck,List<Vector2> listToAdd,int NegativeOrPositive)
    {
        Vector2 vectorX = new Vector2(vector.x + indexX* NegativeOrPositive, vector.y);
        Vector2 vectorY = new Vector2(vector.x , vector.y+indexY* NegativeOrPositive);
        foreach (Vector2 currentVector in listToCheck)
        {
            if (vectorX.Equals(currentVector)&&indexX<=2)
            {
                indexX++;
                Debug.Log(vectorX);
            }
             if (indexX > 2 || !listToAdd.Contains(currentVector))
            {
                listToAdd.Add(vectorX);
            }
            if (vectorY.Equals(currentVector)&&indexY<=2)
            {
                indexY++;
            }
             if (indexY > 2 || !listToAdd.Contains(currentVector))
            {
                listToAdd.Add(vectorY);
            }
        }
    }
 
    private void ResetSameFileTileList()
    {
        tilesData.locsOfSameTypeTiles.Clear();
        tilesData.SwapableLocs.Clear();
    }
}
