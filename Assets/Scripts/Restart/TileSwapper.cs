using UnityEngine;

public class TilesSwaperAssistant : MonoBehaviour
{
    TilesData tilesData;

    private SpriteRenderer sprite;


    public static BoxesData.TypeNPrefab currentTile;
    public static BoxesData.TypeNPrefab nextTile;

    public bool Debug;

    public BoxesData.TypeNPrefab debugCurrent, devugNext;
    private void Start()
    {
        tilesData = GetComponent<TilesData>();
        sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        SelectionIndicator();
        debugCurrent = currentTile;
        devugNext = nextTile;
    }
    private void OnMouseDown()
    {
        Selected();
        Swap(currentTile.selected && nextTile.selected);
    }
    private void OnMouseUp()
    {
    }
    private void SelectionIndicator()
    {
        if ((gameObject.Equals(currentTile.currentObject) && currentTile.selected) || (gameObject.Equals(nextTile.currentObject) && nextTile.selected))
        {
            sprite.color = Color.grey;
        }
        else
        {
            sprite.color = Color.white;
        }
    }
    private void Selected()
    {
        if (currentTile.currentObject == null)
        {
            currentTile = tilesData.tile;
            currentTile.selected = true;
        }
        else if (nextTile.currentObject == null)
        {
            nextTile = tilesData.tile;
            nextTile.selected = true;
        }
    }
    private void DeselectTile(BoxesData.TypeNPrefab currentTile, bool resetBools)
    {
        currentTile.prefab = null;
        currentTile.currentObject = null;
        if (resetBools)
            currentTile.selected = false;
    }
    public void Swap(bool swap)//needs to check if both tiles are selected
    {
        if (swap)
        {
            SwapTiles();
        }

    }
    private void SwapTiles()
    {

        BoxesData.TypeNPrefab tempTile = nextTile;
        //prepares swap Next
        nextTile.prefab = currentTile.prefab;
        nextTile.boxType = currentTile.boxType;
        nextTile.sprite = currentTile.sprite;

        //preparas swap first sellected
        currentTile.prefab = tempTile.prefab;
        currentTile.boxType = tempTile.boxType;
        currentTile.sprite = tempTile.sprite;

        //changes instance of current
        currentTile.currentObject.GetComponent<TilesData>().tile = currentTile;
        //changes instance of next
        nextTile.currentObject.GetComponent<TilesData>().tile = nextTile;


        currentTile = new BoxesData.TypeNPrefab();
        nextTile = new BoxesData.TypeNPrefab();


    }
}
