using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwiperDataForTiles : MonoBehaviour
{
    public enum Direction
    {
        up, down, left, right
    }
    [Header("GiaDebugMono")]
    public Direction whatISTheDir;

    public int column;
    public int row;
    public int _TargetX;
    public int _TargetY;

    private BoxStates currentBoxState;
    private Vector2 currentPos;
    private BackgroudCreator backgroud;
    private SpawnObjects spawn;
    [SerializeField]
    private float angle;
    private Vector2 initialPos = Vector2.zero;
    private Vector2 finalPos;
    private void Awake()
    {
        spawn = FindObjectOfType<SpawnObjects>();
        backgroud = FindObjectOfType<BackgroudCreator>();
        currentBoxState = GetComponent<BoxStates>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _TargetX = (int)GetComponentInParent<Transform>().position.x;
        column = _TargetX;
        _TargetY = (int)GetComponentInParent<Transform>().position.y;
        row = _TargetY;
        currentPos = new Vector2(_TargetX, _TargetY);

    }

    // Update is called once per frame
    void Update()
    {
        currentPos = new Vector2(column, row);
        transform.position = currentPos;
        gameObject.name = "Tile in: " + currentPos;
    }

    private void OnMouseDown()
    {

        initialPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    private void OnMouseUp()
    {
        finalPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        AngleCalculator();
    }
    private void AngleCalculator()
    {
        float distanceX, DistanceY;
        distanceX = finalPos.x - initialPos.x;
        DistanceY = finalPos.y - initialPos.y;
        angle = Mathf.Atan2(DistanceY, distanceX) * 180 / Mathf.PI;
        TypeOfMovementCalc();
    }
    private void TypeOfMovementCalc()
    {
        if (angle > 45 && angle < 135 && row < backgroud.height - 1)
        {
            whatISTheDir = Direction.up;
        }
        if (angle < 45 && angle > -45 && column < backgroud.width - 1)
        {
            whatISTheDir = Direction.right;
        }
        if (angle < -45 && angle > -135 && row > 0)
        {
            whatISTheDir = Direction.down;
        }
        if ((angle > 135 || angle < -135) && column > 0)
        {
            whatISTheDir = Direction.left;
        }

        TileMovement();

    }

    private void TileMovement()
    {
        GameObject otherdot;
        switch (whatISTheDir)
        {
            case Direction.up:
                otherdot = spawn._Tiles[column, row + 1];
                otherdot.GetComponent<SwiperDataForTiles>().row -= 1;
                row++;
                break;
            case Direction.right:
                otherdot = spawn._Tiles[column + 1, row];
                otherdot.GetComponent<SwiperDataForTiles>().column -= 1;
                column++;
                break;
            case Direction.left:
                otherdot = spawn._Tiles[column - 1, row];
                otherdot.GetComponent<SwiperDataForTiles>().column += 1;
                column--;
                break;
            case Direction.down:
                otherdot = spawn._Tiles[column, row - 1];
                otherdot.GetComponent<SwiperDataForTiles>().row += 1;
                row--;
                break;
        }
        StartCoroutine(ResetVariablesAfterMovementChange());
    }

    IEnumerator ResetVariablesAfterMovementChange()
    {
        yield return new WaitForSeconds(1f);
        initialPos = Vector2.zero;
        finalPos = Vector2.zero;
    }
    private bool CanDestroyHorizontal()
    {
        GameObject horizontalDotLeft, HorizontalDotRight;
        horizontalDotLeft = spawn._Tiles[column - 1, row];
        HorizontalDotRight = spawn._Tiles[column + 1, row];
        BoxStates LeftObjState, RightObjState;
        LeftObjState = horizontalDotLeft.GetComponent<BoxStates>();
        RightObjState = HorizontalDotRight.GetComponent<BoxStates>();

        if (currentBoxState._BoxType.Equals(RightObjState._BoxType & LeftObjState._BoxType))
        {
            return true;
        }

        return false;
    }
    private bool CanDestroyVertical()
    {
        GameObject VerticaDotDown, VerticalDotUp;
        VerticaDotDown = spawn._Tiles[column , row - 1];
        VerticalDotUp = spawn._Tiles[column , row + 1];
        BoxStates DownObjectState, UpObjectState;
        DownObjectState = VerticaDotDown.GetComponent<BoxStates>();
        UpObjectState = VerticalDotUp.GetComponent<BoxStates>();

        if (currentBoxState._BoxType.Equals(UpObjectState._BoxType & DownObjectState._BoxType))
        {
            return true;
        }

        return false;
    }
    private void DestroyAndApplyScoreIfTrue(bool toDestroyOrCheck)
    {
        if (CanDestroyHorizontal()||CanDestroyVertical())
        {
            //apply score
            Destroy(gameObject);
            //spawn
        }
    }
}
