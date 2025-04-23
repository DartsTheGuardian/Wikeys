using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DragCard : MonoBehaviour, IDragHandler, IDropHandler
{
    public static Action<Transform> OnDropCard;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnDropCard?.Invoke(this.transform);
        Debug.Log("snap!");
    }
}
