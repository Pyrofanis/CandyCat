using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Maching Cat Items")]
    [Min(0)]
    public GameObject[] _MachingBoxes;

    [Header("Time For Each Object To Spawn")]
    [Range(0.1f, 2f)]
    public float _SpawnTime = 0.1f;

    [Header("SpawnPoint Edges")]
    [Tooltip("The Edges to spawn In Current Line")]
    [Min(2)]
    public Transform[] _SpawnPoints;

    [Header("Layer Of MachingBoxes")]
    public LayerMask _MachingBoxLayer;

    //[Header("Maximum blocks to start with")]
    //[Range(20, 160)]
    //public int _MaximumInitialBoxes = 40;
    [Header("ExtraBoxes")]
    [Tooltip("Will Affect Spawning Rate Also")]
    [Range(1, 160)]
    public int _ExtraBoxes = 20;

    [Header("Distance Between Boxes")]
    [Range(1, 4)]
    public float _DistanceBox;

    private int width = 0, height = 0;
    private float timer;
    private Vector3 _CurrentSpawnPoint;

    private void Awake()
    {
        width = 0; height = 0;
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
        if (timer > _SpawnTime || timer.Equals(0))
        {
            timer = 0;
            Spawn(SpawnPoint());
        }
    }
    private void Spawn(Vector3 PositionToInstanciate)
    {
        GameObject currentTile = Instantiate(
                     _MachingBoxes[Random.Range(0, _MachingBoxes.Length)]
                     , PositionToInstanciate
                     , Quaternion.identity
                     ) ;
        currentTile.transform.SetParent(transform);
        currentTile.name = "_( " + height + "," + width + " )_";
    }
    private Vector3 SpawnPoint()
    {
        _CurrentSpawnPoint.z = 0;
        if (_CurrentSpawnPoint.x >= _SpawnPoints[1].transform.position.x)
        {
            _CurrentSpawnPoint.x = _SpawnPoints[0].position.x;
            _CurrentSpawnPoint.y -= _DistanceBox;
            height++;
            width = 0;
        }
        else
        {
            width++;
            _CurrentSpawnPoint += new Vector3(_DistanceBox, 0, 0);
        }
        return _CurrentSpawnPoint;

    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(_SpawnPoints[0].position
        //    , _SpawnPoints[1].position);
        //Gizmos.DrawWireCube(_CurrentSpawnPoint, _DistanceBox * Vector3.one);
    }
}
