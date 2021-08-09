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
            List<BoxesData.TypeNPrefab> currentCombo = new List<BoxesData.TypeNPrefab>();
            currentCombo = SwappingCheckerNMatches.CombinationsFound(types, types.currentObject);

            if (types.boxType != BoxesData.BoxTypes.none)
                ClearMatches.ClearCurrentMatch(currentCombo, types, true);

            ResetTiles.ResetTilesColider();

        }
    }
}
