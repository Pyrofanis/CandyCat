using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxStates : MonoBehaviour
{
    public enum States
    {
        circle,
        square,
        triangle,
        hole

    }
    public enum ActivityState
    {
        Selected,
        deselected
    }
    [Header("The Type Of Box")]
    [Tooltip("What type it is")]
    public States _BoxType;

    [HideInInspector]
    public Spawner spawner;


    [HideInInspector]
    public Rigidbody2D rb;

    private void Awake()
    {
        //spawner = GameObject.FindObjectOfType<Spawner>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireCube(transform.position, Vector2.one * 3 * spawner._DistanceBox);
    }
}
