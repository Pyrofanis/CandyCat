using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AdjustentTiles),typeof(SwappingCheckerNMatches),typeof(TileSwapper))]
[RequireComponent(typeof(ClearMatches),typeof(ResetTiles),typeof(ShiftingTiles))]
[RequireComponent(typeof(Combos))]
public class TileSelection : MonoBehaviour
{
    public static BoxesData.TypeNPrefab current;
    public static BoxesData.TypeNPrefab next;
    [Header("Debug Values only")]
    public  BoxesData.TypeNPrefab dbgC,dbgN;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dbgC = current;
        dbgN = next;
    }


}
