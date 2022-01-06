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
                    Physics.gravity = new Vector3(0, strength);
                    gotoDirection = Handle_Controller.Directions.Down;
                }break;
            case (int) Handle_Controller.Directions.Right:
                {
                    Physics.gravity = new Vector3(-strength,0);
                    gotoDirection = Handle_Controller.Directions.Right;
                }
                break;
            case (int) Handle_Controller.Directions.Up:
                {
                    Physics.gravity = new Vector3(0, -strength);
                    gotoDirection = Handle_Controller.Directions.Up;
                }
                break;
            case (int) Handle_Controller.Directions.Left:
                {
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
