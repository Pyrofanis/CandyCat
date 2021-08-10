using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackground : MonoBehaviour
{
    [Header("Backgroudn Prefab")]
    [SerializeField]
    private GameObject backgroundPrefab;

    public static GameObject[,] bgArrayList;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        bgArrayList = new GameObject[SpawnBoxes.staticGameArray.x, SpawnBoxes.staticGameArray.y];
        CreateTilesBackground();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void CreateTilesBackground()
    {
        for (int x = 0; x < SpawnBoxes.staticGameArray.x; x++)
        {
            for (int y = 0; y < SpawnBoxes.staticGameArray.y; y++)
            {


                InstantiateBackground(x, y);

            }
        }
    }
    public void InstantiateBackground(int x, int y)
    {
        GameObject background = Instantiate(backgroundPrefab, transform.position + new Vector3(x, y), Quaternion.identity,transform);
        bgArrayList[x, y] = background;
    }
}
