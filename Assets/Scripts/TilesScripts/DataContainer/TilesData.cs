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
        Vector2Int coords =Vector2Int.CeilToInt(transform.position);
        SpawnBoxes.arrayList[coords.x, coords.y] = tile;
    }
    private void UpdateTile()
    {
        sprite.sprite = tile.sprite;
        string coordsString = "(" + Mathf.RoundToInt(transform.position.x) + "," + Mathf.RoundToInt(transform.position.y) + ")";
        if (tile.prefab != null)
            gameObject.name = tile.prefab.name + coordsString;
        else gameObject.name = "Empty"+coordsString;

        tile.currentObject = gameObject;
    }
}
