using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlaceSwaper),typeof(AvailableLocs))]
public class TilesData : MonoBehaviour
{

    [HideInInspector]
    public SpawnBoxes parentSpawnBoxes;

    [HideInInspector]
    public Vector3 currentPosition;
    [HideInInspector]
    public Vector3 mousePos;

    [HideInInspector]
    public BoxesData.TypeNPrefab nextType;
    [HideInInspector]
    public BoxesData.TypeNPrefab thisType;



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
    }
    private void UpdateMap()
    {
        currentMap = parentSpawnBoxes.typeNPrefabs;
    }

    public Vector2Int Boundaries()
    {
        //get axes
        int x = Mathf.RoundToInt(transform.position.x - 1);
        int y = Mathf.RoundToInt(transform.position.y);
        //limit  X axes
        if ((x > parentSpawnBoxes.gameArray.x))
        {
            x = parentSpawnBoxes.gameArray.x;
        }
        else if (x <= 0)
        {
            x = 0;
        }
        //limit y axes
        if ((y > parentSpawnBoxes.gameArray.y))
        {
            y = parentSpawnBoxes.gameArray.y;
        }
        else if (y <= 0)
        {
            y = 0;
        }
        return new Vector2Int(x, y);
    }
}
