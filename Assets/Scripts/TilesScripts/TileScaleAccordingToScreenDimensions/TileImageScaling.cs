using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileImageScaling : MonoBehaviour
{
    private RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponentInChildren<RectTransform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        float sizeX = Camera.main.pixelWidth / (SpawnBoxes.staticGameArray.x*2);
        float sizeY = Camera.main.pixelHeight / (SpawnBoxes.staticGameArray.y*1.2f);
        rectTransform.sizeDelta = new Vector2(sizeX, sizeY);
    }
}
