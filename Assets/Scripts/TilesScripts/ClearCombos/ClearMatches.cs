using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMatches : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void ClearCombo(List<BoxesData.TypeNPrefab> currentList,BoxesData.TypeNPrefab nextType)
    {
        if (currentList.Count >= 2)
        {
            for (int i = 0; i < currentList.Count; i++)
            {
                currentList[i].currentObject.GetComponent<TilesData>().tile.boxType = BoxesData.BoxTypes.none;
                currentList[i].currentObject.GetComponent<TilesData>().tile.prefab =null;
                currentList[i].currentObject.GetComponent<TilesData>().tile.sprite =null;
            }
            nextType.currentObject.GetComponent<TilesData>().tile.boxType = BoxesData.BoxTypes.none;
            nextType.currentObject.GetComponent<TilesData>().tile.prefab = null;
            nextType.currentObject.GetComponent<TilesData>().tile.sprite = null;
        }

    }
}
