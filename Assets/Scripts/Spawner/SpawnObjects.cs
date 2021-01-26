using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [Header("Maching Cat Items")]
    [Min(0)]
    public GameObject[] _MachingBoxes;
    public GameObject[,] _Tiles;
    private BackgroudCreator backgroudCreator;
    private void Awake()
    {
        backgroudCreator = GetComponent<BackgroudCreator>();
        _Tiles = new GameObject[backgroudCreator.width, backgroudCreator.height];

    }
    public void SpawnGameTiles(Vector3 PositionToInstanciate, Transform parentTransform, Vector2 Name)
    {

        GameObject currentTile = Instantiate(
                     _MachingBoxes[Random.Range(0, _MachingBoxes.Length)]
                     , PositionToInstanciate
                     , Quaternion.identity
                     );
        currentTile.transform.SetParent(parentTransform);
        currentTile.name = "Tile In:" + Name.ToString("0,0");
        Vector2Int posInArray =new Vector2Int(Mathf.RoundToInt(Name.x),
            Mathf.RoundToInt(Name.y)
            ) ;
        InsertToArray(posInArray, currentTile);
        
    }
    private void InsertToArray(Vector2Int pos,GameObject objectToAddInArray)
    {
        _Tiles[pos.x, pos.y] = objectToAddInArray;
    }
}
