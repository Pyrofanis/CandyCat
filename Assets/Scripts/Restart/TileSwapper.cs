using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TileSwapper : MonoBehaviour
{
    private TilesData tilesData;

    private SpriteRenderer sprite;


    public static BoxesData.TypeNPrefab currentTile;
    public static BoxesData.TypeNPrefab nextTile;

    private SpawnBoxes spawnBoxes;

    public BoxesData.TypeNPrefab debugCur, debugNext;

    [SerializeField]
    private bool matchFound;

    public List<GameObject> dbuglist;

    private Vector2[] castDir = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
    private void Start()
    {
        tilesData = GetComponent<TilesData>();
        sprite = GetComponent<SpriteRenderer>();
        spawnBoxes = GetComponentInParent<SpawnBoxes>();
    }
    // Update is called once per frame
    void Update()
    {
        debugCur = currentTile;
        debugNext = nextTile;
        //if (!tilesData.tile.boxType.Equals(BoxesData.BoxTypes.none))
        //ClearMatchAll(gameObject);
        if (currentTile.currentObject != null)
            SelectionIndicator();
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
        if (gameObject.Equals(currentTile.currentObject) || gameObject.Equals(nextTile.currentObject))
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
    //swapping
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
        TilesData currentTiledata = currentTile.currentObject.GetComponent<TilesData>();
        currentTiledata.tile = currentTile;
        //changes instance of next
        TilesData nextTileData = nextTile.currentObject.GetComponent<TilesData>();
        nextTileData.tile = nextTile;

        ClearMatchAll(currentTile.currentObject);
        ClearMatchAll(nextTile.currentObject);

        StartCoroutine(spawnBoxes.ReFill());

        currentTile = new BoxesData.TypeNPrefab();
        nextTile = new BoxesData.TypeNPrefab();
        
    }
    //swapping

    //adjustent tiles
    private GameObject AdjustentTile(GameObject gameObject, Vector2 castDir)
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, castDir);
        if (hit.collider != null && hit.collider.GetComponent<TilesData>().tile.boxType.Equals(tilesData.tile.boxType))
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
    //adjustent tiles

    //matching
    private List<GameObject> FindMatches(GameObject gameObject, Vector2 castDir)
    {
        List<GameObject> matchingTiles = new List<GameObject>();
        RaycastHit2D hit2D = Physics2D.Raycast(gameObject.transform.position, castDir);
        while (hit2D.collider != null && hit2D.collider.GetComponent<TilesData>().tile.boxType.Equals(gameObject.GetComponent<TilesData>().tile.boxType))
        {
            if (!matchingTiles.Contains(hit2D.collider.gameObject))
                matchingTiles.Add(hit2D.collider.gameObject);
            else
            {
                hit2D.collider.enabled = false;
            }
            hit2D = Physics2D.Raycast(transform.position, castDir);
        }
        return matchingTiles;
    }
    private void ClearMatch(GameObject gameObject, Vector2[] directions)
    {
        List<GameObject> matchingTiles = new List<GameObject>();
        for (int i = 0; i < directions.Length; i++)
        {
            matchingTiles.AddRange(FindMatches(gameObject, directions[i]));
            dbuglist.AddRange(FindMatches(gameObject, directions[i]));
        }
        if (matchingTiles.Count >= 2)
        {
            foreach (GameObject @object in matchingTiles)
            {
                @object.GetComponent<TilesData>().tile = new BoxesData.TypeNPrefab();
            }
            matchFound = true;
        }
    }
    private void ClearMatchAll(GameObject gameObject)
    {
        ClearMatch(gameObject, new Vector2[] { Vector2.up, Vector2.down });//vertical
        ClearMatch(gameObject, new Vector2[] { Vector2.left, Vector2.right });//horizontal
        if (this.matchFound)
        {
            gameObject.GetComponent<TilesData>().tile = new BoxesData.TypeNPrefab();
            matchFound = false;
        }

    }
    //matching
}
