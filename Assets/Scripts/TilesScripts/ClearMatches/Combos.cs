using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combos : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (!ShiftingTiles.shifts)
            ClearCombos();
    }
    private void ClearCombos()
    {
        foreach (BoxesData.TypeNPrefab types in SpawnBoxes.arrayList)
        {
            ClearMatches.ClearCurrentMatch(SwappingCheckerNMatches.CombinationsFound(types, types.currentObject),types);
        }
    }
}
