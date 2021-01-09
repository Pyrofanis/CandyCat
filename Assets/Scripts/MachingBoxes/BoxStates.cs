using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxStates : MonoBehaviour
{
    public enum States{
        circle,
        square,
        triangle

    }
    [Header("The Type Of Box")]
    [Tooltip("What type it is")]
    public States _BoxType;

    private Spawner spawner;
    private Cursor cursor;
    public bool canDestroy;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindObjectOfType<Spawner>();
        cursor = GameObject.FindObjectOfType<Cursor>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ChecknDestroy(canDestroy);
    }
    private void OnMouseOver()
    {
        MoveBlock(KeyCode.Mouse0);
    }
    private void MoveBlock(KeyCode keyCode)
    {
        if (Input.GetKey(keyCode))
        {
            Vector3 PosToMove = new Vector3(
                    cursor.MousePosition().x
                    , cursor.MousePosition().y
                    , transform.position.z);
            transform.position = PosToMove;
            canDestroy = true;

        }
        else
        {
            canDestroy = false;

        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("FreezeBox"))
    //    {
    //        tag = "FreezeBox";
    //        rb.constraints = RigidbodyConstraints2D.FreezeAll;

    //    }
    //}
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("UnfreezeBox"))
    //    {
    //        tag = "UnfreezeBox";
    //        rb.constraints = RigidbodyConstraints2D.None;
    //        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
    //        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    //    }
    //}
    void ChecknDestroy(bool xanDestroy)
    {
        Collider2D[] boxesAround = Physics2D.OverlapBoxAll(
            transform.position
            ,Vector2.one*spawner._DistanceBox
            ,0
            , spawner._MachingBoxLayer); 
        
        if (boxesAround.Length > 3&&xanDestroy)
        {
            DoAForeach(boxesAround);
        }
    
    }
    private void DoAForeach(Collider2D[] boxes)
    {
        foreach(Collider2D coli in boxes)
        {
            Destroy(coli.gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Vector2.one*3 * spawner._DistanceBox);
    }
}
