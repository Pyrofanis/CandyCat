using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSupport : MonoBehaviour
{
    public static  MainControlls inputActions;


    private SpawnBoxes spawnBoxes;
    private int x;
    private int y;

    private void Awake()
    {
        inputActions = new MainControlls();
        spawnBoxes = GameObject.FindObjectOfType<SpawnBoxes>();
    }
    // Start is called before the first frame update
    void Start()
    {
        inputActions.Enable();
        inputActions.Controlls.MoveLeft.performed += _ => DecreaseInt(x);
        inputActions.Controlls.MoveRight.performed += _ => IncreaseInt(x);
        inputActions.Controlls.MoveDown.performed += _ => DecreaseInt(y);
        inputActions.Controlls.MoveUp.performed += _ => IncreaseInt(y);
    }

    // Update is called once per frame
    void Update()
    {
        //if (CanStartActions())
        //    SpawnBoxes.bgArrayList[xRange(), yRange()].GetComponent<SpriteRenderer>().color = Color.green;
    }
    private int xRange()
    {
        if (x <= 0)
        {
            x = 0;
        }
        else if (x >= SpawnBoxes.staticGameArray.x)
        {
            x = SpawnBoxes.staticGameArray.x - 1;
        }

        return x;
    }
    private int yRange()
    {
        if (y < 0)
        {
            y = 0;
        }
        else if (y >= SpawnBoxes.staticGameArray.y)
        {
            y = SpawnBoxes.staticGameArray.y - 1;
        }

        return x;
    }
    private void IncreaseInt(int intToIncrease)
    {
        intToIncrease++;
    }
    private void DecreaseInt(int intToDecrease)
    {
        intToDecrease--; 
    }
    private bool CanStartActions()
    {
        if (spawnBoxes.activeTiles.Count >= SpawnBoxes.staticGameArray.x * SpawnBoxes.staticGameArray.y)
        {
            return true;
        }
        else return false;
    }
}
