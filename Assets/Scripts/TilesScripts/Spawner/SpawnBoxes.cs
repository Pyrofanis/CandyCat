using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxes : MonoBehaviour
{
    [SerializeField]
    public Vector2Int gameArray;
    [SerializeField]
    protected List<BoxesData.TypeNPrefab> Prefabs;

    [Header("Backgroudn Prefab")]
    [SerializeField]
    private GameObject backgroundPrefab;

    [SerializeField]
    [Header("Active Prefabs In Scene")]
    public  List<BoxesData.TypeNPrefab> activeTiles;

    [HideInInspector]
    [SerializeField]
    private List<BoxesData.TypeNPrefab> avainableTiles;

    private BoxesData.TypeNPrefab previousLeft;
    private BoxesData.TypeNPrefab prebiousBellow;

    [Header("Time for Shifting Delay")]
    [Range(0,1)]
    public float shiftingTileDelay;

    public static Vector2Int staticGameArray;
    public static float staticShiftingTileDelay;

    public static BoxesData.TypeNPrefab[,] arrayList;
    public static GameObject[,] bgArrayList;
    // Start is called before the first frame update
    void Awake()
    {
        staticGameArray = gameArray;
        arrayList = new BoxesData.TypeNPrefab[gameArray.x, gameArray.y];
        bgArrayList = new GameObject[gameArray.x, gameArray.y];
        staticShiftingTileDelay = shiftingTileDelay;
    }
    private void Start()
    {
        SpawnObjs(gameArray.x, gameArray.y);
    }
    private void Update()
    {
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
                GameObject objectToEdit = Instantiate(currentPrefab, transform.position + new Vector3(x, y), Quaternion.identity, this.transform);
                objectToEdit.name = boxTypes.ToString() + "( " + x + "," + y + ")";

                Sprite currentSprite = objectToEdit.GetComponent<SpriteRenderer>().sprite;

                TilesData tilesData = objectToEdit.GetComponent<TilesData>();
                InstantiateBackground(x, y);

                BoxesData.TypeNPrefab currentTypeNPrefab = new BoxesData.TypeNPrefab(currentPrefab,objectToEdit,currentSprite, boxTypes,new Vector2Int(x,y));
                tilesData.tile = currentTypeNPrefab;

                activeTiles.Add(currentTypeNPrefab);
                arrayList[x, y] = currentTypeNPrefab;

            }
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
                Sprite currentSprite = avainableTiles[index].prefab.GetComponent<SpriteRenderer>().sprite;
                arrayList[x, y].currentObject.GetComponent<TilesData>().tile.sprite = currentSprite;
                arrayList[x, y].currentObject.GetComponent<TilesData>().tile.prefab = currentPrefab;
                arrayList[x, y].currentObject.GetComponent<TilesData>().tile.boxType = type;
            }
        }
    }
    private void InstantiateBackground(int x,int y)
    {
        GameObject background = Instantiate(backgroundPrefab, transform.position + new Vector3(x, y), Quaternion.identity, transform);
        bgArrayList[x, y] = background;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position+ new Vector3(gameArray.x, gameArray.y) / 2, new Vector3(gameArray.x, gameArray.y) + Prefabs[0].prefab.transform.localScale);
    }
}