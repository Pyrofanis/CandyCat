using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [Header("Maching Cat Items")]
    [Min(0)]
    public GameObject[] _MachingBoxes;
    // Start is called before the first frame update
    public  void SpawnGameTiles(Vector3 PositionToInstanciate, Transform parentTransform, Vector2 Name)
    {

        GameObject currentTile = Instantiate(
                     _MachingBoxes[Random.Range(0, _MachingBoxes.Length)]
                     , PositionToInstanciate
                     , Quaternion.identity
                     );
        currentTile.transform.SetParent(parentTransform);
        currentTile.name = "Tile In:" + Name.ToString("0,0");
    }
}
