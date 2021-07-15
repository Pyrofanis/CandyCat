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
    private void OnMouseDrag()
    {
        FindSameTypeTiles();
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
    private void ResetSameFileTileList()
    {
        tilesData.locsOfSameTypeTiles.Clear();
    }
}
