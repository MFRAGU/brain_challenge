using UnityEngine;
using UnityEngine.EventSystems;

public class HoverCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Texture2D cursorOnEnter;
    public Texture2D cursorOnExit;
    private readonly CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;


    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorOnEnter, hotSpot, cursorMode);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorOnExit, hotSpot, cursorMode);
    }

    public void TriggerPointerExit()
    {
        Cursor.SetCursor(cursorOnExit, hotSpot, cursorMode);
    }
}
