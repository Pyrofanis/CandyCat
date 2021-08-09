using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSwapper : MonoBehaviour
{
    public bool canSwap;//in its place you will put the swap void in its else play a trigger animation

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TileSelection.current.currentObject!=null&&TileSelection.next.currentObject!=null)
        areSelectionsViable();
    }
    private void areSelectionsViable()
    {
        List<BoxesData.TypeNPrefab> currentCombos = SwappingCheckerNMatches.CombinationsFound(TileSelection.current, TileSelection.next.currentObject);
        List<BoxesData.TypeNPrefab> nextCombos = SwappingCheckerNMatches.CombinationsFound(TileSelection.next, TileSelection.current.currentObject);
        if (currentCombos.Count >= 2)
        {
            Swap(TileSelection.current, TileSelection.next,currentCombos,nextCombos);
        }
        else
        {
            CantSwap(TileSelection.current);
        }
    }
    private void Swap(BoxesData.TypeNPrefab current,BoxesData.TypeNPrefab next,List<BoxesData.TypeNPrefab> currentList, List<BoxesData.TypeNPrefab> nextList)
    {
        BoxesData.TypeNPrefab tempType = current;
        current.currentObject.GetComponent<TilesData>().tile.boxType = next.boxType;
        current.currentObject.GetComponent<TilesData>().tile.prefab = next.prefab;
        current.currentObject.GetComponent<TilesData>().tile.sprite = next.sprite;

        next.currentObject.GetComponent<TilesData>().tile.boxType = tempType.boxType;
        next.currentObject.GetComponent<TilesData>().tile.prefab = tempType.prefab;
        next.currentObject.GetComponent<TilesData>().tile.sprite = tempType.sprite;

        ClearMatches.ClearCurrentMatch(currentList, TileSelection.next);
        ClearMatches.ClearCurrentMatch(nextList, TileSelection.current);

        ResetTiles.ResetTilesColider();
        ResetTiles.ResetSelections();
    }
    private void CantSwap(BoxesData.TypeNPrefab current)
    {
        current.currentObject.GetComponent<Animator>().Play("CantSwipe");
        ResetTiles.ResetSelections();
        ResetTiles.ResetTilesColider();
        
    }
}
