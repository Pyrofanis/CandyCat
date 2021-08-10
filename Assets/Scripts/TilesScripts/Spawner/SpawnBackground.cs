using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBackground : MonoBehaviour
{
    [Header("Backgroudn Prefab")]
    [SerializeField]
    private GameObject backgroundPrefab;

    [Header("Backgroudn Prefab")]
    [SerializeField]
    private GameObject verticalPrefab;


    [HideInInspector]
    [SerializeField]
    private List<GameObject> verticalObjects;
    private GameObject horizontalLayoutObj;
    public static GameObject[,] bgArrayList;
    private void Awake()
    {
        horizontalLayoutObj = GetComponentInChildren<HorizontalLayoutGroup>().gameObject;
        CreateVerticalLParents();
    }
    // Start is called before the first frame update
    void Start()
    {
        bgArrayList = new GameObject[SpawnBoxes.staticGameArray.x, SpawnBoxes.staticGameArray.y];
        CreateTilesBackground();
    }
    private void CreateVerticalLParents()
    {
        GameObject currentVertical;
        for (int x = 0; x < SpawnBoxes.staticGameArray.x; x++)
        {
            currentVertical = Instantiate(verticalPrefab, transform.position + new Vector3(x, 0), Quaternion.identity, horizontalLayoutObj.transform);
            if (currentVertical != null)
                verticalObjects.Add(currentVertical);
        }
    }
    private void CreateTilesBackground()
    {
        for (int x = 0; x < SpawnBoxes.staticGameArray.x; x++)
        {
            for (int y = 0; y < SpawnBoxes.staticGameArray.y; y++)
            {
                InstantiateBackground(x, y,verticalObjects[x].transform);
            }
        }
    }
    public void InstantiateBackground(int x, int y,Transform parentTransf)
    {
        GameObject background = Instantiate(backgroundPrefab, transform.position + new Vector3(x, y), Quaternion.identity, parentTransf);
        bgArrayList[x, SpawnBoxes.staticGameArray.y-1-y] = background;
    }
}
