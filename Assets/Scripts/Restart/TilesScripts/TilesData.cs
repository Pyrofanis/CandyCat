using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlaceSwaper),typeof(AvailableLocs))]
public class TilesData : MonoBehaviour
{

    [HideInInspector]
    public SpawnBoxes parentSpawnBoxes;

    //[HideInInspector]
    public Vector3 initialPos;
    //[HideInInspector]
    public Vector3 mousePos;

    [HideInInspector]
    public BoxesData.TypeNPrefab nextType;
    [HideInInspector]
    public BoxesData.TypeNPrefab thisType;

    public bool debugLog;

    public List<BoxesData.TypeNPrefab> currentMap;

    public List<Vector2> locsOfSameTypeTiles;
    // Start is called before the first frame update
    void Start()
    {
        parentSpawnBoxes = transform.parent.GetComponent<SpawnBoxes>();
        currentMap = parentSpawnBoxes.typeNPrefabs;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMap();
        Vector2Int initalPosInt = Vector2Int.CeilToInt(initialPos);
        Vector2Int NewPos = initalPosInt + Movements();
        if (debugLog)
        Debug.Log(NewPos);
    }
    private void UpdateMap()
    {
        currentMap = parentSpawnBoxes.typeNPrefabs;
    }
    public Vector2Int WhereToMove()
    {
        Vector2Int initalPosInt = Vector2Int.CeilToInt(initialPos);
        Vector2Int NewPos= initalPosInt + Movements();
        if (NewPos != Boundaries())
        {
            return NewPos;
        }
        else
        {
            return initalPosInt;
        }
    }
    private Vector2Int Movements()
    { 
        return Vector2Int.CeilToInt(initialPos - mousePos);
    }
    private Vector2Int Boundaries()
    {
        return new Vector2Int(parentSpawnBoxes.gameArray.x,parentSpawnBoxes.gameArray.y);
    }
}
