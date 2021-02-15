using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCreator : MonoBehaviour
{
    [Header("Dimensions")]
    public int width, height;
    [Header("Prefabs")]
    [Min(1)]
    public GameObject[] _Tiles;
    [Min(1)]
    public GameObject[] _BackgroundTiles;

    public GameObject[,] background;
    public GameObject[,] Tiles;
    private void Awake()
    {
        background = new GameObject[width, height];
        Tiles = new GameObject[width, height];
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y=0; y<height; y++)
            {
                Spawner(x, y, _BackgroundTiles,transform);
                Spawner(x, y, _Tiles, transform);
            }  
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (Tiles[x,y]==null)
                {
                    Spawner(x, y, _Tiles, transform);
                }
            }
        }
    }
    private void Spawner(int x,int y,GameObject[] prefab,Transform parent) 
    {
        GameObject _ObjectToInstansiate;
        GameObject _CurrentObject;
        string WhatItIs;
        Vector3Int pos = new Vector3Int(x, y,0);
        if (prefab.Length > 1)
        {
            _ObjectToInstansiate = prefab[Random.Range(0, prefab.Length)];
            WhatItIs = "Tile :";
        }
        else
        {
            _ObjectToInstansiate = prefab[0];
            WhatItIs = "Background :";
        }
        _CurrentObject = Instantiate(_ObjectToInstansiate, pos, Quaternion.identity);
        _CurrentObject.name.Equals(WhatItIs + x + " ," + y);
        _CurrentObject.transform.parent = parent;
        if (WhatItIs.Contains("Tile"))
        {
            Tiles[x, y] = _CurrentObject;
        }
        else
        {
            background[x, y] = _CurrentObject;
        }
    }
}
