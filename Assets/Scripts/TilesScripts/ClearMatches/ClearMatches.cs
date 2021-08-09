using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMatches : MonoBehaviour
{
    public static void ClearCurrentMatch(List<BoxesData.TypeNPrefab> currentList,BoxesData.TypeNPrefab nextType,bool isItCombo)
    {
        if (currentList.Count >= 2)
        {
            for (int i = 0; i < currentList.Count; i++)
            {
                ScoreManager.AddScore(isItCombo);
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
