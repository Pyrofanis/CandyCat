using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combos : MonoBehaviour
{
    public void Update()
    {
        if (!ShiftingTiles.shifts)
            ClearCombos();
    }
    public static void ClearCombos()
    {
        foreach (BoxesData.TypeNPrefab types in SpawnBoxes.arrayList)
        {
            ClearMatches.ClearCurrentMatch(SwappingCheckerNMatches.CombinationsFound(types, types.currentObject),types);
            ResetTiles.ResetTilesColider();
        }
    }
}
