using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchNDestroy : MonoBehaviour
{
    private string currentName;

    private Vector3 currentPosition;
    private Vector3 nextPosition;

    public GameObject nextObj;

    public Vector2Int position;
    public string currentNameSearch;

    private SpawnBoxes parentSpawnBoxes;

    public List<BoxesData.TypeNPrefab> currentMap;
    // Start is called before the first frame update
    void Start()
    {
        parentSpawnBoxes = transform.parent.GetComponent<SpawnBoxes>();
        currentMap = parentSpawnBoxes.typeNPrefabs;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMap();
    }
    private void UpdateMap()
    {
        currentMap = parentSpawnBoxes.typeNPrefabs;
    }
    private void OnMouseDown()
    {
        currentName = gameObject.name;
        currentPosition = gameObject.transform.position;
    }
    private void OnMouseDrag()
    {
        StickToMouse();
        FindNearestTile();
    }
    private void OnMouseUp()
    {
        //gameObject.name=cur
    }
    private void StickToMouse()
    {
        Vector3 cameraPos =new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,5);
        transform.position = cameraPos;
    }
    private void FindNearestTile()
    {
        int x = Mathf.RoundToInt(transform.position.x);
        int y = Mathf.RoundToInt(transform.position.y);
        Vector2Int currentRoundedPosition = new Vector2Int(x, y);

        position = currentRoundedPosition;
        foreach(BoxesData.TypeNPrefab type in currentMap)
        {
            Vector2 coordinates = new Vector2(type.x, type.y);
            if (coordinates.Equals(currentRoundedPosition))
            {
                nextObj = type.prefab;
            }
            
        }
    }
}
