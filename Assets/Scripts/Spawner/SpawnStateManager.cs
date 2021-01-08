using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class SpawnStateManager : MonoBehaviour
{   
    [Header("ExtraBoxes")]
    [Tooltip("Will Affect Spawning Rate Also")]
    [Range(1,30)]
    public int _ExtraBoxes = 20;
    private Spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfReachedMaximumHeight();
    }
    void CheckIfReachedMaximumHeight()
    { 
        Collider2D[] MachingBoxes = Physics2D.OverlapCircleAll(transform.position, 5, spawner._MachingBoxLayer);
        if (MachingBoxes.Length >= 20)
        {
            SpawnerStates.ChangeState(SpawnerStates.States.DoNothing);
        }
        else
        {
            SpawnerStates.ChangeState(SpawnerStates.States.Spawn);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 5);
    }

}
