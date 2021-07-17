using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxes : MonoBehaviour
{
    [SerializeField]
    public BoxesData.GameArray gameArray;
    [SerializeField]
    public List<BoxesData.TypeNPrefab> Prefabs;
    [Header("Active Prefabs In Scene")]
    public List<BoxesData.TypeNPrefab> typeNPrefabs;

    public BoxesData.TypeNPrefab[,] arrayList;
    // Start is called before the first frame update
    void Awake()
    {
        arrayList = new BoxesData.TypeNPrefab[gameArray.x, gameArray.y];
    }
    private void Start()
    {
        SpawnObjs(gameArray.x, gameArray.y);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SpawnObjs(int lengthX, int lengthY)
    {
        for (int x = 0; x < lengthX; x++)
        {
            for (int y = 0; y < lengthY; y++)
            {
                int index = Random.Range(0, Prefabs.Count);
                GameObject currentPrefab = Prefabs[index].prefab;
                BoxesData.BoxTypes boxTypes = Prefabs[index].boxType;

                GameObject objectToEdit = Instantiate(currentPrefab, transform.position + new Vector3(x, y), Quaternion.identity, this.transform);
                objectToEdit.name = boxTypes.ToString() + "( " + x + "," + y + ")";

                TilesData tilesData = objectToEdit.GetComponent<TilesData>();

                BoxesData.TypeNPrefab currentTypeNPrefab = new BoxesData.TypeNPrefab(objectToEdit, boxTypes, x, y);
                tilesData.thisType = new BoxesData.TypeNPrefab(objectToEdit, boxTypes, x, y);

                typeNPrefabs.Add(currentTypeNPrefab);
                arrayList[x, y] = currentTypeNPrefab;

            }
        }
    }
    private void CheckForAllAvailableMaches(BoxesData.TypeNPrefab[,] currentMap, BoxesData.TypeNPrefab currentType)
    {
        //check by rows and collumns for pairs of two eg xxo
        //x check pos
        CheckIfMachingCollumnOrRowIsCreated(1, 0, 1, currentMap, currentType);
        //x check neg
        CheckIfMachingCollumnOrRowIsCreated(1, 0, -1, currentMap, currentType);
        //y check pos
        CheckIfMachingCollumnOrRowIsCreated(0, 1, 1, currentMap, currentType);
        //y check neg
        CheckIfMachingCollumnOrRowIsCreated(0, 1, -1, currentMap, currentType);

        //checks if a midsection is created ej xox by rows and collumns
        //x check
        MidPosCheckCollumnRow(1, 0, currentMap, currentType);
        //y check
        MidPosCheckCollumnRow(0, 1, currentMap, currentType);
    }
    private void CheckIfMachingCollumnOrRowIsCreated(int indexX, int indexY, int negativeOrPositve, BoxesData.TypeNPrefab[,] map, BoxesData.TypeNPrefab swapableCordsVector)
    {
        int offsetXCoord1 = LimitAxes(swapableCordsVector.x + indexX * negativeOrPositve, true);
        int offsetYCoord1 = LimitAxes(swapableCordsVector.y + indexY * negativeOrPositve, false);
        int offsetXCoord2 = LimitAxes(offsetXCoord1 + 1 * indexX * negativeOrPositve, true);
        int offsetYCoord2 = LimitAxes(offsetYCoord1 + 1 * indexY * negativeOrPositve, false);

        BoxesData.TypeNPrefab coord1Obj = map[offsetXCoord1, offsetYCoord1];
        BoxesData.TypeNPrefab coord2Obj = map[offsetXCoord2, offsetYCoord2];

        Vector2Int coord1 = Vector2Int.CeilToInt(new Vector2(coord1Obj.x, coord1Obj.y));
        Vector2Int coord2 = Vector2Int.CeilToInt(new Vector2(coord2Obj.x, coord2Obj.y));
        //if type in coord 1 is equal to type in coord 2 and coord 1 equals two current object and coord1 obj different with coord2
        if (coord1Obj.boxType.Equals(coord2Obj.boxType) && coord1Obj.boxType.Equals(swapableCordsVector.boxType) && coord1 != coord2)
        {

        }

    }
    private void MidPosCheckCollumnRow(int indexX, int indexY, BoxesData.TypeNPrefab[,] map, BoxesData.TypeNPrefab swapableCordsVector)
    {
        int offsetXCoord1 = LimitAxes(swapableCordsVector.x + indexX, true);
        int offsetYCoord1 = LimitAxes(swapableCordsVector.y + indexY, false);
        int offsetXCoord2 = LimitAxes(offsetXCoord1 - indexX, true);
        int offsetYCoord2 = LimitAxes(offsetYCoord1 - indexY, false);

        BoxesData.TypeNPrefab coord1Obj = map[offsetXCoord1, offsetYCoord1];
        BoxesData.TypeNPrefab coord2Obj = map[offsetXCoord2, offsetYCoord2];

        Vector2 coord1 = new Vector2(coord1Obj.x, coord1Obj.y);
        Vector2 coord2 = new Vector2(coord2Obj.x, coord2Obj.y);
        //if type in coord 1 is equal to type in coord 2 and coord 1 equals two current object and coord1 obj different with coord2
        if (coord1Obj.boxType.Equals(coord2Obj.boxType) && coord1Obj.boxType.Equals(swapableCordsVector.boxType) && coord1 != coord2)
        {

        }

    }
    private int LimitAxes(int coordToLimit, bool horizontalAxes)
    {
        if (horizontalAxes)
        {
            return Mathf.Clamp(coordToLimit, 0, gameArray.x - 1);
        }
        else
        {
            return Mathf.Clamp(coordToLimit, 0, gameArray.y - 1);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + new Vector3(gameArray.x, gameArray.y) / 2, new Vector3(gameArray.x, gameArray.y));
    }
}
