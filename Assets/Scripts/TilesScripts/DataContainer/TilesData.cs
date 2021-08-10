using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(PlaceSwaper),typeof(AvailableLocs))]
public class TilesData : MonoBehaviour
{
    //[HideInInspector]
    public BoxesData.TypeNPrefab tile;

    private SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {

        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        UpdateMap();
        UpdateTile();
    }
    private void UpdateMap()
    {
        SpawnBoxes.arrayList[tile.objectCoords.x, tile.objectCoords.y] = tile;
    }
    private void UpdateTile()
    {
        sprite.sprite = tile.sprite;
        string coordsString = "(" + Mathf.RoundToInt(tile.objectCoords.x) + "," + Mathf.RoundToInt(tile.objectCoords.y) + ")";
        if (tile.prefab != null)
            gameObject.name = tile.prefab.name + coordsString;
        else gameObject.name = "Empty"+coordsString;

        tile.currentObject = gameObject;
    }
}
