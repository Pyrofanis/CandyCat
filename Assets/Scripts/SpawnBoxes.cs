using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxes : MonoBehaviour
{
    [SerializeField]
    public BoxesData.GameArray gameArray;
    [SerializeField]
    protected List<BoxesData.TypeNPrefab> Prefabs;
    [SerializeField]
    [Header("Active Prefabs In Scene")]
    private List<BoxesData.TypeNPrefab> typeNPrefabs;

    [HideInInspector]
    [SerializeField]
    private List<BoxesData.TypeNPrefab> avainableTiles;
    private BoxesData.TypeNPrefab previousLeft;
    private BoxesData.TypeNPrefab prebiousBellow;
    private BoxesData.TypeNPrefab nextAbove;

    [Header("Time for Shifting Delay")]
    [Range(0,1)]
    public float shiftingTileDelay;


    public static BoxesData.TypeNPrefab[,] arrayList;
    // Start is called before the first frame update
    void Awake()
    {
        arrayList = new BoxesData.TypeNPrefab[gameArray.x, gameArray.y];
    }
    private void Start()
    {
        SpawnObjs(gameArray.x, gameArray.y);
    }
    private void SpawnObjs(int lengthX, int lengthY)
    {
        for (int x = 0; x < lengthX; x++)
        {
            for (int y = 0; y < lengthY; y++)
            {


                //randomize and remove unwanted
                 Randomizer(x, y,false);

                int index = Random.Range(0, avainableTiles.Count);
                GameObject currentPrefab = avainableTiles[index].prefab;
                BoxesData.BoxTypes boxTypes = avainableTiles[index].boxType;
                GameObject objectToEdit = Instantiate(currentPrefab, transform.position + new Vector3(x, y), Quaternion.identity, this.transform);
                objectToEdit.name = boxTypes.ToString() + "( " + x + "," + y + ")";

                Sprite currentSprite = objectToEdit.GetComponent<SpriteRenderer>().sprite;

                TilesData tilesData = objectToEdit.GetComponent<TilesData>();

                BoxesData.TypeNPrefab currentTypeNPrefab = new BoxesData.TypeNPrefab(currentPrefab,objectToEdit,currentSprite, boxTypes,false);
                tilesData.tile = new BoxesData.TypeNPrefab(currentPrefab, objectToEdit, currentSprite, boxTypes,false);

                typeNPrefabs.Add(currentTypeNPrefab);
                arrayList[x, y] = currentTypeNPrefab;

            }
        }
    }
    private void Randomizer(int x,int y,bool reshifting)
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
        if (reshifting&&y+1<gameArray.y)
        {
            nextAbove = arrayList[x, y + 1];
            if (avainableTiles.Count>1)
            avainableTiles.Remove(nextAbove);
        }
    }

    public IEnumerator  ReFill()
    {
        for (int x = 0; x < gameArray.x; x++)
        {
            yield return new WaitForSeconds(shiftingTileDelay/4);

            for (int y = 0; y < gameArray.y; y++)
            {
                yield return new WaitForSeconds(shiftingTileDelay/4);

                if (arrayList[x, y].boxType.Equals(BoxesData.BoxTypes.none))
                {
                    Randomizer(x, y,true);

                    int index = Random.Range(0, avainableTiles.Count);
                    GameObject currentPrefab = avainableTiles[index].prefab;
                    BoxesData.BoxTypes boxTypes = avainableTiles[index].boxType;
                    Sprite sprite = avainableTiles[index].prefab.GetComponent<SpriteRenderer>().sprite;
                    arrayList[x, y].currentObject.GetComponent<TilesData>().tile.prefab = currentPrefab;
                    arrayList[x, y].currentObject.GetComponent<TilesData>().tile.boxType = boxTypes;
                    arrayList[x, y].currentObject.GetComponent<TilesData>().tile.sprite = sprite;
                    arrayList[x, y].currentObject.GetComponent<Collider2D>().enabled = true;
                }
            }
        }
    }
    private void Shifting(int x,int y)
    {

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + new Vector3(gameArray.x, gameArray.y) / 2, new Vector3(gameArray.x, gameArray.y));
    }
}
