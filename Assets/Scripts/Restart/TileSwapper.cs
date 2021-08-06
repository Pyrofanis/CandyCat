using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TileSwapper : MonoBehaviour
{
   private TilesData tilesData;

    private SpriteRenderer sprite;


    public static BoxesData.TypeNPrefab currentTile;
    public static BoxesData.TypeNPrefab nextTile;

    public BoxesData.TypeNPrefab debugCur, debugNext;
    public List<GameObject> gameObjects;

    private Vector2[] castDir = new Vector2[]{ Vector2.up, Vector2.down, Vector2.left, Vector2.right };
    private void Start()
    {
        tilesData = GetComponent<TilesData>();
        sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        debugCur = currentTile;
        debugNext = nextTile;
        if (currentTile.currentObject!=null)
        gameObjects = AdjustentTiles(currentTile.currentObject);
        SelectionIndicator();
    }
    private void OnMouseDown()
    {
        Selected();
        Swap(currentTile.selected && nextTile.selected);
        Debug.Log(tilesData.tile.currentObject.name);
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
        else if (AdjustentTiles(currentTile.currentObject).Contains(tilesData.tile.currentObject))
        {
            nextTile = tilesData.tile;
            nextTile.selected = true;
        }
        else
        {
            currentTile = tilesData.tile;
            currentTile.selected = true;
        }
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
    private GameObject AdjustentTile(GameObject gameObject,Vector2 castDir)
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, castDir);
        if (hit.collider != null)
        {
            return hit.collider.gameObject;
        }
        return null;
    }
    private List<GameObject> AdjustentTiles(GameObject gameObject)
    {
       List<GameObject> adjustenredTiles = new List<GameObject>();
        for (int i = 0; i < castDir.Length; i++)
        {
            adjustenredTiles.Add(AdjustentTile(gameObject, castDir[i]));
        }
        return adjustenredTiles;
    }
}
