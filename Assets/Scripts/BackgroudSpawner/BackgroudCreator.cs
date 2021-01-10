using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroudCreator : MonoBehaviour
{  
    [Min(1)]
    public int height;
    [Min(1)]
    public int width;

    public GameObject _TilePrefab;
    private GameObject[,] _BackgroudPrefab;
    private void Awake()
    {
        _BackgroudPrefab = new GameObject[width, height];

    }
    // Start is called before the first frame update
    void Start()
    {
        SetUpBackgroud();
    }

    private void SetUpBackgroud()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2 tempPos = new Vector2(x, y);
                Instantiate(_TilePrefab, tempPos, Quaternion.identity);
            }
        }
    }
}
