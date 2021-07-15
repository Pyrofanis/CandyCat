using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceSwaper : MonoBehaviour
{
    private string currentName;

   


    public Vector2Int position;
    public string currentNameSearch;




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
   
    private void OnMouseDown()
    {
        currentName = gameObject.name;
        tilesData.initialPos = gameObject.transform.position;
    }
    private void OnMouseDrag()
    {
        StickToMouse();
        FindNearestTile();
    }
    private void OnMouseUp()
    {
        SwapPlaces(true);
    }
    private void StickToMouse()
    {
        Vector3 mousPosRaw = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 5);
        float x = mousPosRaw.x ;
        float y = mousPosRaw.y;
        Vector3Int mousPosEdited = Vector3Int.CeilToInt(new Vector3(x, y,5));
        tilesData.mousePos = mousPosEdited;
        transform.position = tilesData.mousePos;
    }
    private void FindNearestTile()
    {
        position = tilesData.WhereToMove();
        foreach (BoxesData.TypeNPrefab type in tilesData.currentMap)
        {
            Vector2 coordinates = new Vector2(type.x, type.y);
            if (coordinates.Equals(tilesData.WhereToMove()))
            {
                tilesData.nextType = type;
            }
        }
    }
    private void SwapPlaces(bool canU)
    {
        if (canU)
        {
            //renaming
            gameObject.name = tilesData.nextType.prefab.name;
            tilesData.nextType.prefab.name = currentName;

            //changing parameters this obj
            gameObject.transform.position = tilesData.nextType.prefab.transform.position;
            tilesData.thisType.x = Mathf.RoundToInt(tilesData.nextType.prefab.transform.position.x);
            tilesData.thisType.y = Mathf.RoundToInt(tilesData.nextType.prefab.transform.position.y);

            //changing parameters targeted obj
            tilesData.nextType.prefab.transform.position = tilesData.initialPos;
            tilesData.nextType.x = Mathf.RoundToInt(transform.position.x);
            tilesData.nextType.y = Mathf.RoundToInt(transform.position.y);

            //resetting
            currentName = "";
            tilesData.nextType = new BoxesData.TypeNPrefab();

        }
    }

    private void OnDrawGizmos()
    {
        if (tilesData.nextType.prefab != null && tilesData.initialPos != Vector3.zero)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(tilesData.initialPos, tilesData.nextType.prefab.transform.position);
        }
           
    }
}
