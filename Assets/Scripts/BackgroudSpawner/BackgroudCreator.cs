using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroudCreator : MonoBehaviour
{ 
    [Header("Background Dimensions")]
    [Range(1,99)]
    public int height;
    [Range(1, 99)]
    public int width;
    [Header("Background Sprite")]
    public GameObject _TilePrefab;
    [Header("Position To Start Tiling")]
    public Transform _StartingPos;
    [HideInInspector]
    public GameObject[,] _BackgroudPrefab;
    private SpawnObjects spawnObjects;

    private void Awake()
    {
        _BackgroudPrefab = new GameObject[width, height];
        spawnObjects = GetComponent<SpawnObjects>();

    }
    // Start is called before the first frame update
    void Start()
    {
        SetUpBackgroud();
    }
    private void Update()
    {

    }

    private void SetUpBackgroud()
    {

        for (int x =0; x< width; x++)
        {
            for (int y =0;y< height; y++)
            {
                Vector2 name = new Vector2(x, y);
                Vector2 initialPos =_StartingPos.position*(Vector2.right+Vector2.up);
                //Vector2 tempPos = initialPos + name;
                BackgroundTileSpawner(name, name);


            }
        }
    }
    private void BackgroundTileSpawner(Vector2 posToSpawn,Vector2 _NameOfOBject)
    {
        GameObject backGroundTile = Instantiate(_TilePrefab, posToSpawn, Quaternion.identity);
        backGroundTile.name = _NameOfOBject.ToString("0,0");
        backGroundTile.transform.SetParent(transform);
        spawnObjects.SpawnGameTiles(posToSpawn,transform,_NameOfOBject);
    }


}
