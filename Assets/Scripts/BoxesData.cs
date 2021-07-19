using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoxesData 
{
    public  enum BoxTypes{
        type1,
        type2,
        type3
    }
    [System.Serializable]

    public struct TypeNPrefab
    {
        public GameObject prefab;
        public BoxTypes boxType;
        public int x;
        public int y;
        public TypeNPrefab(GameObject newOBJ,BoxTypes newType,int newX,int newY)
        {
            this.prefab = newOBJ;
            this.boxType = newType;
            this.x = newX;
            this.y = newY;
        }
    }
    [System.Serializable]
    public struct GameArray
    {
        public int x;
        public int y;
        private GameObject[] spawnedObjs;
        public GameArray (int newX,int NewY,GameObject[] newObjs)
        {
            this.x = newX;
            this.y = NewY;
            this.spawnedObjs = newObjs;
        }
    }
}
