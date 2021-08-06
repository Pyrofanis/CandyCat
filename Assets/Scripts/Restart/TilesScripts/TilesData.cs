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
        UpdateTileVisually();
    }
    private void UpdateMap()
    {
        Vector2Int coords =Vector2Int.CeilToInt(transform.position);
        SpawnBoxes.arrayList[coords.x, coords.y] = tile;
    }
    private void UpdateTileVisually()
    {
        sprite.sprite = tile.sprite;
        gameObject.name = tile.prefab.name+"("+Mathf.RoundToInt(transform.position.x)+","+Mathf.RoundToInt(transform.position.y)+")";
    }
}
