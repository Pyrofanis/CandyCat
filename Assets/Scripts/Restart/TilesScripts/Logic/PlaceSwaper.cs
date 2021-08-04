using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceSwaper : MonoBehaviour
{
    private string currentName;

   


    public Vector2 position;
    public string currentNameSearch;

    public bool stopMovement;
    public bool canSwap;

    private TilesData tilesData;
    // Start is called before the first frame update
    void Start()
    {
        tilesData = GetComponent<TilesData>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TilesData>() != null)
        {
            TilesData adjastentedTile = collision.GetComponent<TilesData>();
            tilesData.nextTile = adjastentedTile;
            stopMovement = true;
        }
    }
    private void OnMouseDown()
    {
        currentName = gameObject.name;
        tilesData.initialPos = gameObject.transform.localPosition;
        GetMousePos();
    }
    private void OnMouseDrag()
    {
        GetMousePos();
        StickToMouse();
        CheckIfItIsSwapable();
    }
    private void OnMouseUp()
    {
        SwapPlaces(stopMovement&&canSwap);
    }
    private void GetMousePos()
    {
        Vector3 mousPosRaw = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        tilesData.mousePos = mousPosRaw;//world to local
    }
    private void StickToMouse()
    {
        if (!stopMovement)
        transform.localPosition =new Vector2(tilesData.mousePos.x,tilesData.mousePos.y);
    }
    private void SwapPlaces(bool canU)
    {
        if (canU)
        {
            //renaming
            gameObject.name = tilesData.nextTile.gameObject.name;
            tilesData.nextTile.gameObject.name = currentName;

            //changing parameters this obj
            gameObject.transform.localPosition = new Vector2(tilesData.nextTile.thisType.x, tilesData.nextTile.thisType.y);
            tilesData.thisType.x = Mathf.RoundToInt(tilesData.nextTile.thisType.prefab.transform.localPosition.x);
            tilesData.thisType.y = Mathf.RoundToInt(tilesData.nextTile.thisType.prefab.transform.localPosition.y);

            //changing parameters targeted obj
            tilesData.nextTile.gameObject.transform.localPosition = new Vector2(tilesData.initialPos.x,tilesData.initialPos.y);
            tilesData.nextTile.thisType.x = Mathf.RoundToInt(tilesData.initialPos.x);
            tilesData.nextTile.thisType.y = Mathf.RoundToInt(tilesData.initialPos.y);

            //changing initial pos both objects
            tilesData.initialPos = new Vector2(tilesData.thisType.x, tilesData.thisType.y);

            //get tiles data of next type
            TilesData nextTile = tilesData.nextTile.thisType.prefab.gameObject.GetComponent<TilesData>();

            //change initial pos of next tile
            nextTile.initialPos = new Vector2(tilesData.nextTile.thisType.x, tilesData.nextTile.thisType.y);

            //resetting
            currentName = "";
            tilesData.nextTile = new TilesData();
            stopMovement = false;
            

        }
        else if (stopMovement)
        {
            //reseting to default
            gameObject.transform.localPosition = new Vector2(tilesData.initialPos.x, tilesData.initialPos.y);
            stopMovement = false;
        }
    }
    void CheckIfItIsSwapable()
    {
        foreach(Vector2 coords in tilesData.swapableLocs)
        {
            if (coords.Equals(new Vector2(tilesData.nextTile.thisType.x, tilesData.nextTile.thisType.y)))//if it maches the coordinates that are acceptable it swaps
            {
                canSwap = true;
            }
            else
            {
                canSwap = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (tilesData.nextTile != null && tilesData.initialPos != Vector3.zero)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(tilesData.initialPos, tilesData.nextTile.thisType.prefab.transform.localPosition);
        }
           
    }   
}
