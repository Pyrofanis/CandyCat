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

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TilesData>() != null)
        {
            TilesData adjastentedTile = collision.GetComponent<TilesData>();
            tilesData.nextType = adjastentedTile.thisType;
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
            gameObject.name = tilesData.nextType.prefab.name;
            tilesData.nextType.prefab.name = currentName;

            //changing parameters this obj
            gameObject.transform.localPosition = new Vector2(tilesData.nextType.x, tilesData.nextType.y);
            tilesData.thisType.x = Mathf.RoundToInt(tilesData.nextType.prefab.transform.localPosition.x);
            tilesData.thisType.y = Mathf.RoundToInt(tilesData.nextType.prefab.transform.localPosition.y);

            //changing parameters targeted obj
            tilesData.nextType.prefab.transform.localPosition = new Vector2(tilesData.initialPos.x,tilesData.initialPos.y);
            tilesData.nextType.x = Mathf.RoundToInt(tilesData.initialPos.x);
            tilesData.nextType.y = Mathf.RoundToInt(tilesData.initialPos.y);

            //resetting
            currentName = "";
            tilesData.nextType = new BoxesData.TypeNPrefab();
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
            if (coords.Equals(new Vector2(tilesData.nextType.x, tilesData.nextType.y)))//if it maches the coordinates that are acceptable it swaps
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
        if (tilesData.nextType.prefab != null && tilesData.initialPos != Vector3.zero)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(tilesData.initialPos, tilesData.nextType.prefab.transform.localPosition);
        }
           
    }
}
