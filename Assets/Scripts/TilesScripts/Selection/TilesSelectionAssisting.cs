using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesSelectionAssisting : MonoBehaviour
{
    private TilesData tilesData;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        tilesData = GetComponent<TilesData>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SelectionIndexer();
    }
    private void OnMouseDown()
    {
        Selections();
    }
    private void Selections()
    {
        if (TileSelection.current.currentObject == null)
        {
            TileSelection.current = tilesData.tile;
        }
        else if (TileSelection.next.currentObject == null && TileSelection.current.currentObject != tilesData.tile.currentObject)
        {
            TileSelection.next = tilesData.tile;
        }
        else
        {
            TileSelection.current = new BoxesData.TypeNPrefab();
            TileSelection.next = new BoxesData.TypeNPrefab();
        }
    }
    private void SelectionIndexer()
    {
        if (TileSelection.current.Equals(tilesData.tile) || TileSelection.next.Equals(tilesData.tile))
        {
            spriteRenderer.color = Color.gray;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }
}
