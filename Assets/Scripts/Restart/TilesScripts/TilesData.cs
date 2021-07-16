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
    public Vector3 wheretomove,direction;

    [HideInInspector]
    public BoxesData.TypeNPrefab nextType;
    [HideInInspector]
    public BoxesData.TypeNPrefab thisType;

    public bool debugLog;

    public List<BoxesData.TypeNPrefab> currentMap;

    public List<Vector2> locsOfSameTypeTiles;

    public List<Vector2> SwapableLocs;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = new Vector3(transform.localPosition.x,transform.localPosition.y,5);
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

}
