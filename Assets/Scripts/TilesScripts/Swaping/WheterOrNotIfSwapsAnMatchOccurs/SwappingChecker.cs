using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwappingChecker : MonoBehaviour
{
    private static Vector2[] horizontal = new Vector2[] { Vector2.left, Vector2.right };
    private static Vector2[] vertical = new Vector2[] { Vector2.up, Vector2.down };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private static List<BoxesData.TypeNPrefab> FindMatches(GameObject wantedTypeOBJ,GameObject castRaysFrom,Vector2 direction)
    {
        List<BoxesData.TypeNPrefab> matches=new List<BoxesData.TypeNPrefab>();
        BoxesData.TypeNPrefab wantedTypeType = wantedTypeOBJ.GetComponent<TilesData>().tile;
        RaycastHit2D hit2D = Physics2D.Raycast(castRaysFrom.transform.position, direction);

        while (hit2D.collider != null && hit2D.collider.GetComponent<TilesData>().tile.boxType.Equals(wantedTypeType.boxType))
        {
            if (!matches.Contains(hit2D.collider.GetComponent<TilesData>().tile))
                matches.Add(hit2D.collider.GetComponent<TilesData>().tile);
            else
                hit2D.collider.enabled = false;         
            hit2D = Physics2D.Raycast(castRaysFrom.transform.position, direction);
     

        }
        return matches;

    }
    private static List<BoxesData.TypeNPrefab> MatchesDimensional(GameObject wantedTypeOBJ, GameObject castRaysFrom, Vector2[] directions)
    {
        List<BoxesData.TypeNPrefab> matchesInThisDimension = new List<BoxesData.TypeNPrefab>();
        foreach(Vector2 dir in directions)
        {
            matchesInThisDimension.AddRange(FindMatches(wantedTypeOBJ, castRaysFrom, dir));
        }
        return matchesInThisDimension;
    }
    public static List<BoxesData.TypeNPrefab> CombinationsFound(GameObject wantedTypeOBJ, GameObject castRaysFrom)
    {
        List<BoxesData.TypeNPrefab> combinations = new List<BoxesData.TypeNPrefab>();
        if (MatchesDimensional(wantedTypeOBJ, castRaysFrom, horizontal).Count >= 2)
        {
            combinations.AddRange(MatchesDimensional(wantedTypeOBJ, castRaysFrom, horizontal));
        }
        if (MatchesDimensional(wantedTypeOBJ, castRaysFrom, vertical).Count >= 2)
        {
            combinations.AddRange(MatchesDimensional(wantedTypeOBJ, castRaysFrom, vertical));
        }
        return combinations;
    }

}
