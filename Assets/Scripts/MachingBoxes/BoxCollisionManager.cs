using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollisionManager : MonoBehaviour
{
    private BoxStates boxStates;
    private Rigidbody2D rb;
    private void Awake()
    {
        boxStates = GetComponent<BoxStates>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = boxStates.rb;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FreezeBox"))
        {
            tag = "FreezeBox";
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("UnfreezeBox"))
        {
            tag = "UnfreezeBox";
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
    }
}
