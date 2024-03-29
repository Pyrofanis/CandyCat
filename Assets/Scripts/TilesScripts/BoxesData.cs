using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoxesData
{
    public enum BoxTypes
    {
        none,
        type1,
        type2,
        type3,
        type4,
        type5,
        type6,
    }
    [System.Serializable]

    public struct TypeNPrefab
    {
        public GameObject prefab;
        [HideInInspector]
        public GameObject currentObject;//the current object to be changed /inital obj like inital pos used to work
        [HideInInspector]
        public Sprite sprite;
        public Sprite defaultSprite;
        public BoxTypes boxType;
        [HideInInspector]
        public Vector2Int objectCoords;
        public TypeNPrefab(GameObject newOBJ, GameObject newCurrentObj, Sprite newSprite,Sprite newDefaultSprite, BoxTypes newType,Vector2Int newCoords)
        {
            this.prefab = newOBJ;
            this.currentObject = newCurrentObj;
            this.sprite = newSprite;
            this.defaultSprite = newDefaultSprite;
            this.boxType = newType;
            this.objectCoords = newCoords;
        }
    }
    [System.Serializable]
    public struct GameArray
    {
        public int x;
        public int y;
        private GameObject[] spawnedObjs;
        public GameArray(int newX, int NewY, GameObject[] newObjs)
        {
            this.x = newX;
            this.y = NewY;
            this.spawnedObjs = newObjs;
        }
    }
}
