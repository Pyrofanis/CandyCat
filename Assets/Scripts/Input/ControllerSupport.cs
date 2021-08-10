using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSupport : MonoBehaviour
{
    public static  MainControlls inputActions;
    public static BoxesData.TypeNPrefab CurrentTileObj;
    public static GameObject CurrentTileBgObj;

    private  bool mouse;

    private int x;
    private int y;

    private void Awake()
    {
        inputActions = new MainControlls();
        mouse = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        inputActions.Enable();
        inputActions.Controlls.MoveLeft.performed += _ => DecreaseInt(true);
        inputActions.Controlls.MoveRight.performed += _ => IncreaseInt(true);
        inputActions.Controlls.MoveDown.performed += _ => DecreaseInt(false);
        inputActions.Controlls.MoveUp.performed += _ => IncreaseInt(false);
        inputActions.Controlls.MouseControll.performed += _ => ActivateMouse();
    }

    // Update is called once per frame
    void Update()
    {
        if (!mouse)
        {
            CurrentTileBgObj = SpawnBoxes.bgArrayList[xRange(), yRange()];
            CurrentTileObj = SpawnBoxes.arrayList[xRange(), yRange()];
        }
        else
        {
            CurrentTileBgObj = null;
            CurrentTileObj = new BoxesData.TypeNPrefab();
        }

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

        return y;
    }
    private void IncreaseInt(bool horizontal)
    {
        if (horizontal) x++;
        else y++;

        mouse = false;
    }
    private void DecreaseInt(bool horizontal)
    {
        if (horizontal)
            x--;
        else y--;

        mouse = false;
    }
    private void ActivateMouse()
    {
        mouse = true;
    }
}
