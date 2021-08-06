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
        public GameObject currentObject;//the current object to be changed /inital obj like inital pos used to work
        public Sprite sprite;
        public BoxTypes boxType;
        public bool selected;

        public TypeNPrefab(GameObject newOBJ,GameObject newCurrentObj,Sprite newSprite,BoxTypes newType,bool newBool)
        {
            this.prefab = newOBJ;
            this.currentObject = newCurrentObj;
            this.sprite = newSprite;
            this.boxType = newType;
            this.selected = newBool;

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
