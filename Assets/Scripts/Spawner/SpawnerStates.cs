using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpawnerStates 
{   public enum States
    {
        Spawn,
        DoNothing,
    }
    public delegate void SpawnStateChanger(States state);
    public static event SpawnStateChanger onSpawnStateChange;

    public static void ChangeState(States state)
    {
        if (onSpawnStateChange != null)
        {
            onSpawnStateChange(state);
        }
    }
}
