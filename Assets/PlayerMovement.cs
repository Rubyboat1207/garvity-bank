using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Vector3 moveVector;
    CharacterController controller;
    [SerializeField]
    float Speed;
    [SerializeField]
    CompassHandler compassHandler;
    [SerializeField]
    Handle_Controller Handle_Controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Kill()
    {
        PlayerData.DeathCount++;
        Handle_Controller.ChangeDirection(Handle_Controller.Directions.Down);
        compassHandler.UpdatePointer();
        Debug.Log("dead");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    // Update is called once per frame
    void Update()
    {
        moveVector *= 0.5f * Time.deltaTime;
        if (controller.isGrounded == false)
        {
            //Add our gravity Vecotr
            moveVector += Physics.gravity;
        }
        Vector3 move = Vector3.zero;
        if ((int) CompassHandler.gotoDirection == 0 ^ (int)CompassHandler.gotoDirection == 180)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }
        if ((int)CompassHandler.gotoDirection == 270 ^ (int)CompassHandler.gotoDirection == 90)
        {
            move = new Vector3(0, Input.GetAxis("Vertical"), 0);
        }
        //Apply our move Vector , remeber to multiply by Time.delta
        controller.Move((moveVector + (move * Speed)) * Time.deltaTime );
    }
}
