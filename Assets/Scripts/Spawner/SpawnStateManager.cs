using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class SpawnStateManager : MonoBehaviour
{   
   
    private Spawner spawner;
    private void Awake()
    {
        spawner = GetComponent<Spawner>();

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfReachedMaximumHeight();
    }
    void CheckIfReachedMaximumHeight()
    { 
        Collider2D[] MachingBoxes = Physics2D.OverlapCircleAll(transform.position, 5, spawner._MachingBoxLayer);
        if (MachingBoxes.Length >= spawner._ExtraBoxes)
        {
            SpawnerStates.ChangeState(SpawnerStates.States.DoNothing);
        }
        else
        {
            Debug.Log(MachingBoxes.Length);
            SpawnerStates.ChangeState(SpawnerStates.States.Spawn);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 5);
    }

}
