using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBoxes : MonoBehaviour
{
    [SerializeField]
    public Vector2Int gameArray;
    [SerializeField]
    protected List<BoxesData.TypeNPrefab> Prefabs;
    [SerializeField]
    [Header("Prefab Of Vertical Layout Ui")]
    private GameObject verticalPrefab;

    [SerializeField]
    [Header("Prefab Of Vertical Layout Ui")]
    private GameObject horizontalayout;

    [SerializeField]
    [Header("Active Prefabs In Scene")]
    public  List<BoxesData.TypeNPrefab> activeTiles;

    [HideInInspector]
    [SerializeField]
    private List<BoxesData.TypeNPrefab> avainableTiles;

    private BoxesData.TypeNPrefab previousLeft;
    private BoxesData.TypeNPrefab prebiousBellow;
    [HideInInspector]
    [SerializeField]
    private List<GameObject> verticalPrefabs;


    public static Vector2Int staticGameArray;

    public static BoxesData.TypeNPrefab[,] arrayList;

    // Start is called before the first frame update
    void Awake()
    {
        horizontalayout=GetComponentInChildren<HorizontalLayoutGroup>().gameObject;
        CreateVerticalPrefabs();
        staticGameArray = gameArray;
        arrayList = new BoxesData.TypeNPrefab[gameArray.x, gameArray.y];
    }
    private void Start()
    {
        SpawnObjs(gameArray.x, gameArray.y);
    }
    private void Update()
    {
        if (activeTiles.Count >= gameArray.x * gameArray.y)
            Refilling();
    }
    private void SpawnObjs(int lengthX, int lengthY)
    {
        for (int x = 0; x < lengthX; x++)
        {
            for (int y = 0; y < lengthY; y++)
            {


                //randomize and remove unwanted
                 Randomizer(x, y);

                int index = Random.Range(0, avainableTiles.Count);
                GameObject currentPrefab = avainableTiles[index].prefab;
                BoxesData.BoxTypes boxTypes = avainableTiles[index].boxType;
                GameObject objectToEdit = Instantiate(currentPrefab, transform.position + new Vector3(x, y), Quaternion.identity, verticalPrefabs[x].transform);
                objectToEdit.name = boxTypes.ToString() + "( " + x + "," + y + ")";

                Sprite currentSprite = objectToEdit.GetComponent<Image>().sprite;

                TilesData tilesData = objectToEdit.GetComponent<TilesData>();

                BoxesData.TypeNPrefab currentTypeNPrefab = new BoxesData.TypeNPrefab(currentPrefab,objectToEdit,currentSprite, boxTypes,new Vector2Int(x, lengthY - 1 - y));
                tilesData.tile = currentTypeNPrefab;

                activeTiles.Add(currentTypeNPrefab);
                arrayList[x, lengthY-1-y] = currentTypeNPrefab;

            }
        }
    }
    private void CreateVerticalPrefabs()
    {
        GameObject currentVertical;
        for (int x = 0; x < gameArray.x; x++)
        {
             currentVertical = Instantiate(verticalPrefab,transform.position+new Vector3(x,0),Quaternion.identity, horizontalayout.transform);
            //currentVertical.GetComponent<RectTransform>().anchorMin = Vector3.zero;
            //currentVertical.GetComponent<RectTransform>().anchorMax = Vector3.one;
            if (currentVertical!=null)
            verticalPrefabs.Add(currentVertical);
        }
    }
    private void Randomizer(int x,int y)
    {
        //prepare available tiles
        avainableTiles.Clear();
        avainableTiles.AddRange(Prefabs);
            
        if (x >0)
        {
            previousLeft = arrayList[x - 1, y];
            previousLeft.currentObject = null;
            previousLeft.sprite = null;
        }

        if (y >0)
        {
            prebiousBellow = arrayList[x, y - 1];
            prebiousBellow.currentObject = null;
            prebiousBellow.sprite = null;
        }
        avainableTiles.Remove(previousLeft);
        avainableTiles.Remove(prebiousBellow);
    }
    private void Refilling()
    {
        int y = gameArray.y - 1;
        for (int x = 0; x < gameArray.x; x++)
        {
            if (arrayList[x, y].boxType==BoxesData.BoxTypes.none)
            {
                Randomizer(x, y);
                int index = Random.Range(0, avainableTiles.Count);
                GameObject currentPrefab = avainableTiles[index].prefab;
                BoxesData.BoxTypes type = avainableTiles[index].boxType;
                Sprite currentSprite = avainableTiles[index].prefab.GetComponent<Image>().sprite;
                arrayList[x, y].currentObject.GetComponent<TilesData>().tile.sprite = currentSprite;
                arrayList[x, y].currentObject.GetComponent<TilesData>().tile.prefab = currentPrefab;
                arrayList[x, y].currentObject.GetComponent<TilesData>().tile.boxType = type;
            }
        }
    }
 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position+ new Vector3(gameArray.x, gameArray.y) / 2, new Vector3(gameArray.x, gameArray.y) + Prefabs[0].prefab.transform.localScale);
    }
}
