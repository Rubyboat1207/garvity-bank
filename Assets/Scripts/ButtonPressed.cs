using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent WhilePressedEvent = new UnityEvent();
    // Use this for initialization
    void Start()
    {

    }
    void Update()
    {
        if (!ispressed)
            return;
        // DO SOMETHING HERE
        WhilePressedEvent.Invoke();
    }
    bool ispressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
    }
}