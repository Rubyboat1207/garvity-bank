using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunOnCollide : MonoBehaviour
{
    public UnityEvent OnCollideEvent = new UnityEvent();
    public UnityEvent OnStopCollideEvent = new UnityEvent();
    public UnityEvent WhileCollide = new UnityEvent();
    private void OnCollisionEnter(Collision collision)
    {
        OnCollideEvent.Invoke();
    }
    private void OnCollisionExit(Collision collision)
    {
        OnStopCollideEvent.Invoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        OnCollideEvent.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        OnStopCollideEvent.Invoke();
    }
    public void OnCollisionStay(Collision collision)
    {
        WhileCollide.Invoke();
    }
    private void OnTriggerStay(Collider other)
    {
        WhileCollide.Invoke();
    }
}
