using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    [Header("Maching Cat Items")]
    [Min(0)]
    public GameObject[] _MachingBoxes;

    [Header("Time For Each Object To Spawn")]
    [Range(0.1f,2f)]
    public float _SpawnTime=0.1f;

    [Header("SpawnPoint Edges")]
    [Tooltip("The Edges to spawn In Current Line")]
    [Min(2)]
    public  Transform[] _SpawnPoints;

    [Header("Layer Of MachingBoxes")]
    public  LayerMask _MachingBoxLayer;

    [Header("Maximum blocks to start with")]
    [Range(20, 80)]
    public int _MaximumInitialBoxes = 40;
    [Header("ExtraBoxes")]
    [Tooltip("Will Affect Spawning Rate Also")]
    [Range(1, 30)]
    public int _ExtraBoxes = 20;

    [Header("Distance Between Boxes")]
    [Range(0.2f, 4)]
    public float _DistanceBox;
    private float timer;

 

    private Vector3 _CurrentSpawnPoint;

    private void Awake()
    {
        for (int i = 0; i <= _MaximumInitialBoxes; i++)
        {
            Spawn();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnerStates.onSpawnStateChange += CheckAndApplyBehaviourAccordingToState;
        _CurrentSpawnPoint = _SpawnPoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    void CheckAndApplyBehaviourAccordingToState(SpawnerStates.States state)
    {
        switch (state)
        {
            case SpawnerStates.States.Spawn:
                SpawnObject();
                break;
        }
    }
    private void SpawnObject()
    {
        if (timer > _SpawnTime||timer.Equals(0))
        {
            timer = 0;
            Spawn();
        }
    }
    private void Spawn()
    {
        Instantiate(
                   _MachingBoxes[Random.Range(0, _MachingBoxes.Length)]
                   , SpawnPoint()
                   , Quaternion.identity
                   );
    }
    private Vector3  SpawnPoint()
    {
        if (_CurrentSpawnPoint.x >= _SpawnPoints[1].transform.position.x)
        {
            _CurrentSpawnPoint = _SpawnPoints[0].position;
        }
        else
        {
            _CurrentSpawnPoint += new Vector3(_DistanceBox, 0, 0);
        }
        return _CurrentSpawnPoint;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(_SpawnPoints[0].position
            ,_SpawnPoints[1].position);
        Gizmos.DrawWireCube(_CurrentSpawnPoint,_DistanceBox*Vector3.one);
    }
}
