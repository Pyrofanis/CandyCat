using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TilesSelectionAssisting : MonoBehaviour, IPointerDownHandler
{
    private TilesData tilesData;
    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        tilesData = GetComponent<TilesData>();
        img = GetComponent<Image>();
        ControllerSupport.inputActions.Controlls.Selection.performed +=_=> ControllerSelection();
    }

    // Update is called once per frame
    void Update()
    {
        SelectionIndexer();
    }
   void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (!ShiftingTiles.shifts)
            Selections();
    }
    private void ControllerSelection()
    {
        if (ControllerSupport.CurrentTileObj.currentObject !=null&& gameObject.Equals(ControllerSupport.CurrentTileObj.currentObject))
        {
            Selections();
        }
    }
    private void Selections()
    {
        if (TileSelection.current.currentObject == null)
        {
            TileSelection.current = tilesData.tile;
        }
        else if (TileSelection.next.currentObject == null && TileSelection.current.currentObject != tilesData.tile.currentObject)
        {
            TileSelection.next = tilesData.tile;
        }
        else
        {
            TileSelection.current = new BoxesData.TypeNPrefab();
            TileSelection.next = new BoxesData.TypeNPrefab();
        }
    }
    private void SelectionIndexer()
    {
        if (TileSelection.current.Equals(tilesData.tile) || TileSelection.next.Equals(tilesData.tile))
        {
            img.color = Color.gray;
        }
        else
        {
            img.color = Color.white;
        }
    }
}
