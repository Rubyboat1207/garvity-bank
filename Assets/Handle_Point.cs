using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle_Point : MonoBehaviour
{
    public Handle_Controller controller;
    public Handle_Controller.Directions direction;
    private void OnMouseDown()
    {
        controller.ChangeDirection(direction);
    }
}
