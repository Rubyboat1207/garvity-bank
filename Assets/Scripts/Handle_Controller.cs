using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handle_Controller : MonoBehaviour
{
    public Transform handle;
    public Transform controller;
    public Camera main_cam;
    public enum Directions
    {
        Down = 0,
        Right = 90,
        Up = 180,
        Left = 270
    }

    private void Start()
    {
        
    }
    void Update()
    {
        handle.position = controller.position;
        if (Input.GetKeyDown(PlayerData.CompassControl_Up))
        {
            ChangeDirection(Directions.Up);
        }
        if (Input.GetKeyDown(PlayerData.CompassControl_Down))
        {
            ChangeDirection(Directions.Down);
        }
        if (Input.GetKeyDown(PlayerData.CompassControl_Left))
        {
            ChangeDirection(Directions.Left);
        }
        if (Input.GetKeyDown(PlayerData.CompassControl_Right))
        {
            ChangeDirection(Directions.Right);
        }
    }
    
    public void ChangeDirection(Directions direction)
    {
        if (CompassHandler.IsDirectionDisabled(direction)) { return; }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, (int) direction));
    }
}
