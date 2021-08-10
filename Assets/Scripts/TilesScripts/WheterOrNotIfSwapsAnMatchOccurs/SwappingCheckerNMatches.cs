using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwappingCheckerNMatches : MonoBehaviour
{
    private static Vector2[] horizontal = new Vector2[] { Vector2.left, Vector2.right };
    private static Vector2[] vertical = new Vector2[] { Vector2.up, Vector2.down };
    private static List<BoxesData.TypeNPrefab> FindMatches(BoxesData.TypeNPrefab wantedType,GameObject castRaysFrom,Vector2 direction)
    {
        List<BoxesData.TypeNPrefab> matches=new List<BoxesData.TypeNPrefab>();
        RaycastHit2D hit2D = Physics2D.Raycast(castRaysFrom.transform.position, direction);
        while (hit2D.collider != null && hit2D.collider.GetComponent<TilesData>().tile.boxType.Equals(wantedType.boxType))
        {
            if (!matches.Contains(hit2D.collider.GetComponent<TilesData>().tile)&&hit2D.collider.gameObject!=wantedType.currentObject)
                matches.Add(hit2D.collider.GetComponent<TilesData>().tile);
            else
                hit2D.collider.enabled = false;         
            hit2D = Physics2D.Raycast(castRaysFrom.transform.position, direction);
     

        }
        return matches;

    }
    private static List<BoxesData.TypeNPrefab> MatchesDimensional(BoxesData.TypeNPrefab wantedType, GameObject castRaysFrom, Vector2[] directions)
    {
        List<BoxesData.TypeNPrefab> matchesInThisDimension = new List<BoxesData.TypeNPrefab>();
        foreach(Vector2 dir in directions)
        {
            matchesInThisDimension.AddRange(FindMatches(wantedType, castRaysFrom, dir));
        }
        return matchesInThisDimension;
    }
    public static List<BoxesData.TypeNPrefab> CombinationsFound(BoxesData.TypeNPrefab wantedType, GameObject castRaysFrom)
    {
        List<BoxesData.TypeNPrefab> combinations = new List<BoxesData.TypeNPrefab>();
        List<BoxesData.TypeNPrefab> horizontalCombo = MatchesDimensional(wantedType, castRaysFrom, horizontal);
        List<BoxesData.TypeNPrefab> verticalCombo = MatchesDimensional(wantedType, castRaysFrom, vertical);

        if (horizontalCombo.Count >= 2)
        {
            combinations.AddRange(horizontalCombo);
        }
        if (verticalCombo.Count >= 2)
        {
            combinations.AddRange(verticalCombo);
        }
        return combinations;
    }

}
