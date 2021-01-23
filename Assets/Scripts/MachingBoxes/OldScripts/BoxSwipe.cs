using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSwipe : MonoBehaviour
{
    private BoxStates boxStates;
    private Vector3 positionOnInput;
    private Spawner spawner;

    private void Awake()
    {
        boxStates = GetComponent<BoxStates>();
    }
    // Start is called before the first frame update
    void Start()
    {
        spawner = boxStates.spawner;
        positionOnInput = Vector3.positiveInfinity;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseOver()
    {
        MoveBlockManager(KeyCode.Mouse0);
    }
    void WhatToDoAccordintToState(BoxStates.ActivityState activity)
    {
        switch (activity)
        {
            case BoxStates.ActivityState.Selected:
                MoveBlock();
                break;

        }
    }
    private void MoveBlockManager(KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode))
        {
            positionOnInput = transform.position;
        }
        if (Input.GetKey(keyCode))
        {
            WhatToDoAccordintToState(BoxStates.ActivityState.Selected);
        }
        if (Input.GetKeyUp(keyCode))
        {
            WhatToDoAccordintToState(BoxStates.ActivityState.deselected);
        }
    }
    void MoveBlock()
    {
        Vector3 PosToMove = new Vector3(
                   Cursor.MousePosition().x
                   , Cursor.MousePosition().y
                   , transform.position.z);
        if (CanMove())
        {
            transform.position = PosToMove;
        }
        else
        {
            transform.position = positionOnInput;
        }
    }

    bool CanMove()
    {
        bool movementX;
        bool movementY;
        if (-positionOnInput.x * spawner._DistanceBox < transform.position.x
           && -positionOnInput.y * spawner._DistanceBox < transform.position.y)
        {
            movementX = true;
        }
        else
        {
            movementX = false;
        }
        if (positionOnInput.x * spawner._DistanceBox > transform.position.x
          && positionOnInput.y * spawner._DistanceBox > transform.position.y)
        {
            movementY = true;
        }
        else
        {
            movementY = false;
        }
        return movementY && movementX;
    }
}
