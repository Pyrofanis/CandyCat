using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BgTileIndicator : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Indicator();
    }
    private void Indicator()
    {
        if (ControllerSupport.CurrentTileBgObj==null)
        {
            spriteRenderer.color = Color.white;
        }
        else if (ControllerSupport.CurrentTileBgObj.Equals(gameObject))
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }
}
