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
    private void SpawnObjs(int lengthX,int lengthY)
    {
        for ( int x = 0; x < lengthX; x++)
        {
            for(int y = 0; y < lengthY; y++)
            {
                int index = Random.Range(0, Prefabs.Count);
                GameObject currentPrefab = Prefabs[index].prefab;
                BoxesData.BoxTypes boxTypes = Prefabs[index].boxType;

                GameObject objectToEdit = Instantiate(currentPrefab, transform.position + new Vector3(x, y), Quaternion.identity,this.transform);
                objectToEdit.name = boxTypes.ToString() + "( " + x + "," + y + ")";

                TilesData tilesData = objectToEdit.GetComponent<TilesData>();

                BoxesData.TypeNPrefab currentTypeNPrefab = new BoxesData.TypeNPrefab(objectToEdit, boxTypes,x,y);
                tilesData.thisType = new BoxesData.TypeNPrefab(objectToEdit, boxTypes,x,y);

                typeNPrefabs.Add(currentTypeNPrefab);
                arrayList[x, y] = currentTypeNPrefab;
                
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position+ new Vector3(gameArray.x, gameArray.y)/2, new Vector3(gameArray.x, gameArray.y));
    }
}
