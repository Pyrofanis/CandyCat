using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingTiles : MonoBehaviour
{
    public static bool shifts;

    private static int nullInThatCollumn = 0;
    // Update is called once per frame
    void Update()
    {
        ShiftDown();

    }
    private static void Shift(List<BoxesData.TypeNPrefab> collumnToShift, int nullObjects)
    {
        for (int i = 0; i < nullObjects; i++)
        {
            for (int z = 0; z < collumnToShift.Count - 1; z++)
            {
                collumnToShift[z].currentObject.GetComponent<TilesData>().tile.boxType = collumnToShift[z + 1].boxType;
                collumnToShift[z].currentObject.GetComponent<TilesData>().tile.prefab = collumnToShift[z + 1].prefab;
                collumnToShift[z].currentObject.GetComponent<TilesData>().tile.sprite = collumnToShift[z + 1].sprite;

                collumnToShift[z + 1].currentObject.GetComponent<TilesData>().tile.boxType = BoxesData.BoxTypes.none;
                collumnToShift[z + 1].currentObject.GetComponent<TilesData>().tile.sprite = collumnToShift[z + 1].currentObject.GetComponent<TilesData>().tile.defaultSprite;
                shifts = true;
            }
        }
    }
    private static void FindNullInCollumn(int x, int initialY)
    {
        List<BoxesData.TypeNPrefab> currentCollumn = new List<BoxesData.TypeNPrefab>();
        for (int y = initialY; y < SpawnBoxes.staticGameArray.y; y++)//epeidi tsekaris kai to apo epano toy prepei na einai entos ton orion
        {
            if (SpawnBoxes.arrayList[x, y].currentObject.GetComponent<TilesData>().tile.boxType.Equals(BoxesData.BoxTypes.none))
            {
                nullInThatCollumn++;
            }
            currentCollumn.Add(SpawnBoxes.arrayList[x, y]);

        }
        Shift(currentCollumn, nullInThatCollumn);
    }
    public static void ShiftDown()
    {
        for (int x = 0; x < SpawnBoxes.staticGameArray.x; x++)
        {
            for (int y = 0; y < SpawnBoxes.staticGameArray.y; y++)
            {
                if (SpawnBoxes.arrayList[x, y].boxType.Equals(BoxesData.BoxTypes.none))
                {
                    FindNullInCollumn(x, y);
                    shifts = true;
                    break;
                }
                else
                {
                    nullInThatCollumn = 0;
                    shifts = false;
                }

            }
        }
    }



}
