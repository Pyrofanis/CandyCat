using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwiperDataForTiles : MonoBehaviour
{
    public enum Direction
    {
        up, down, left, right,none
    }
    [Header("GiaDebugMono")]
    public Direction whatISTheDir;

    public int column;
    public int row;
    public int _TargetX;
    public int _TargetY;

    public bool debug;

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
        whatISTheDir=Direction.none;

    }

    // Update is called once per frame
    void Update()
    {
        //DestroyAndApplyScoreIfTrue();
        if (DistanceHorizontalVertical() >= 0.1f)
        {
            Vector2.Lerp(_CurrentPos(), transform.position ,0.1f*Time.deltaTime);
        }
        else
        {
            transform.position = _CurrentPos();
            gameObject.name = "Tile in: " + new Vector2(column, row);
            spawn._Tiles[column, row] = this.gameObject;
        }
        if (debug) 
        Debug.Log(gameObject.name + "CurrentPosVector:" + _CurrentPos());//theli diorthosi
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
        whatISTheDir=(Direction.none);
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
    private GameObject[] whatToDestroy ()
    {
        GameObject horizontalDotLeft, HorizontalDotRight;
        List<GameObject> horizontalObjects=null;

        GameObject VerticaDotDown, VerticalDotUp;
        List<GameObject> VerticalObjects=null;
       

        if (CanDestroyHorizontal())
        {
            horizontalDotLeft = spawn._Tiles[column - 1, row];
            HorizontalDotRight = spawn._Tiles[column + 1, row];
            horizontalObjects.Add(horizontalDotLeft);
            horizontalObjects.Add(HorizontalDotRight);
            return horizontalObjects.ToArray();
        }
        if (CanDestroyVertical())
        {
            VerticaDotDown = spawn._Tiles[column, row - 1];
            VerticalDotUp = spawn._Tiles[column, row + 1];
            VerticalObjects.Add(VerticaDotDown);
            VerticalObjects.Add(VerticalDotUp);
            return VerticalObjects.ToArray();
        }
        return null;
    }
    private void DestroyAndApplyScoreIfTrue()
    {
        if (CanDestroyHorizontal()||CanDestroyVertical())
        {
            //apply score
            foreach (GameObject _Object in whatToDestroy())
            {
                Destroy(_Object);
            }
        
            StartCoroutine(DestroyWithDelay());
            //spawn
        }
    }
  private  IEnumerator DestroyWithDelay()
    {
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);

    }
    private float DistanceHorizontalVertical()
    {
        if (whatISTheDir == (Direction.up) || whatISTheDir == (Direction.down))
        {
            return finalPos.y - initialPos.y;
        }
        else if (whatISTheDir != Direction.none)
        {
            return finalPos.x - initialPos.x;
        }
        else return 0;

    }
    private Vector2 _CurrentPos() 
    { if (transform.position.x.Equals(column))
        {
            return new Vector2(transform.position.x, _TargetY);
        }
        else if (transform.position.y.Equals(row))
        {
            return new Vector2(_TargetX, transform.position.y);
        }
        else
        {
            return new Vector2(column, row);
        }
    
    }
}
