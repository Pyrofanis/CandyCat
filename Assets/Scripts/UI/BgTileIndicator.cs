using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BgTileIndicator : MonoBehaviour
{
    private Image img;
    private void Awake()
    {
        img = GetComponent<Image>();
    }
    private void Update()
    {
        Indicator();
    }
    private void Indicator()
    {
        if (ControllerSupport.CurrentTileBgObj==null)
        {
            img.color = Color.white;
        }
        else if (ControllerSupport.CurrentTileBgObj.Equals(gameObject))
        {
            img.color = Color.green;
        }
        else
        {
            img.color = Color.white;
        }
    }
}
