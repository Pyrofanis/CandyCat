using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroyAndADDScore : MonoBehaviour
{
    private BoxStates boxStates;
    private Spawner spawner;

    public bool canDestroy;

    private void Awake()
    {
        boxStates = GetComponent<BoxStates>();
    }
    // Start is called before the first frame update
    void Start()
    {
        spawner = boxStates.spawner;

    }

    // Update is called once per frame
    void Update()
    {
        ChecknDestroy(canDestroy);

    }

    void ChecknDestroy(bool xanDestroy)
    {
        Collider2D[] boxesAround = Physics2D.OverlapBoxAll(
            transform.position
            , Vector2.one * spawner._DistanceBox
            , 0
            , spawner._MachingBoxLayer);

        if (boxesAround.Length > 3 && xanDestroy)
        {
            DoAForeach(boxesAround);
        }

    }
    private void DoAForeach(Collider2D[] boxes)
    {
        foreach (Collider2D coli in boxes)
        {
            BoxStates state = coli.gameObject.GetComponent<BoxStates>();
            if (state._BoxType.Equals(boxStates._BoxType))
            {
                Destroy(coli.gameObject);
            }
        }
    }
}
