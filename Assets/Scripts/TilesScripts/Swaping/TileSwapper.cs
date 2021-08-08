using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSwapper : MonoBehaviour
{
    public bool canSwap;

    public List<BoxesData.TypeNPrefab> dbgL;
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
        List<BoxesData.TypeNPrefab> currentCombos = SwappingChecker.CombinationsFound(TileSelection.current.currentObject, TileSelection.next.currentObject);
        dbgL = currentCombos;
        if (currentCombos.Count >= 2)
        {
            canSwap = true;
        }
    }
}
