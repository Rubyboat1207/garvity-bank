using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassHandler : MonoBehaviour
{
    public Transform Pointer;
    public Handle_Controller controller;
    public float strength = -9.8f;
    public float turnspeed;
    public static Handle_Controller.Directions gotoDirection = Handle_Controller.Directions.Down;
    public static bool[] DisabledDirections = { false, false, false, false };

    public static void DisableDirection(Handle_Controller.Directions direction)
    {
        switch (direction)
        {
            case Handle_Controller.Directions.Down: { DisabledDirections[0] = true; break; }
            case Handle_Controller.Directions.Right: { DisabledDirections[1] = true; break; }
            case Handle_Controller.Directions.Up: { DisabledDirections[2] = true; break; }
            case Handle_Controller.Directions.Left: { DisabledDirections[3] = true; break; }
        }
    }

    public static bool IsDirectionDisabled(Handle_Controller.Directions direction)
    {
        switch (direction)
        {
            case Handle_Controller.Directions.Down: { return DisabledDirections[0]; }
            case Handle_Controller.Directions.Right: { return DisabledDirections[1]; }
            case Handle_Controller.Directions.Up: { return DisabledDirections[2]; }
            case Handle_Controller.Directions.Left: { return DisabledDirections[3]; }
        }
        return false;
    }

    public static void EnableDirection(Handle_Controller.Directions direction)
    {
        switch (direction)
        {
            case Handle_Controller.Directions.Down: { DisabledDirections[0] = false; break; }
            case Handle_Controller.Directions.Right: { DisabledDirections[1] = false; break; }
            case Handle_Controller.Directions.Up: { DisabledDirections[2] = false; break; }
            case Handle_Controller.Directions.Left: { DisabledDirections[3] = false; break; }
        }
    }

    private void Update()
    {
        if(Input.GetKey(PlayerData.CompassControl_Confirm))
        {
            UpdatePointer();
        }
    }

    public void UpdatePointer()
    {
        switch(controller.transform.rotation.eulerAngles.z)
        {
            case (int) Handle_Controller.Directions.Down:
                {
                    if (IsDirectionDisabled(Handle_Controller.Directions.Down)) { break; }
                    Physics.gravity = new Vector3(0, strength);
                    gotoDirection = Handle_Controller.Directions.Down;
                }break;
            case (int) Handle_Controller.Directions.Right:
                {
                    if (IsDirectionDisabled(Handle_Controller.Directions.Right)) { break; }
                    Physics.gravity = new Vector3(-strength,0);
                    gotoDirection = Handle_Controller.Directions.Right;
                }
                break;
            case (int) Handle_Controller.Directions.Up:
                {
                    if (IsDirectionDisabled(Handle_Controller.Directions.Up)) { break; }
                    Physics.gravity = new Vector3(0, -strength);
                    gotoDirection = Handle_Controller.Directions.Up;
                }
                break;
            case (int) Handle_Controller.Directions.Left:
                {
                    if (IsDirectionDisabled(Handle_Controller.Directions.Left)) { break; }
                    Physics.gravity = new Vector3(strength, 0);
                    gotoDirection = Handle_Controller.Directions.Left;
                }
                break;
            default:
            break;
        }
        Debug.Log(gotoDirection.ToString());
        Pointer.transform.rotation = Quaternion.Euler(0, 0, (int) gotoDirection);
    }    
}
