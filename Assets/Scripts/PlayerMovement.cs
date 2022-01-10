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
    [SerializeField]
    Vector3 move;
    [SerializeField]
    GameObject MobileControls;
    float autosave_timer;
    public static UnityEngine.Events.UnityEvent OnDeath = new UnityEngine.Events.UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        if (!Application.isMobilePlatform)
        {
            MobileControls.SetActive(false);
        }
        controller = GetComponent<CharacterController>();
        PlayerData.LoadConfig();
        PlayerData.SaveConfig();
    }

    public void Kill()
    {
        PlayerData.DeathCount++;
        OnDeath.Invoke();
        PlayerData.SaveConfig();
        Debug.Log("dead");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeMoveX(float change)
    {
        if (CompassHandler.gotoDirection == Handle_Controller.Directions.Down ^ CompassHandler.gotoDirection == Handle_Controller.Directions.Up)
        {
            Debug.Log("x_worked");
            move = new Vector3(change,0);
            Debug.Log(move);
        }
    }
    public void ChangeMoveY(float change)
    {
        if (CompassHandler.gotoDirection == Handle_Controller.Directions.Left ^ CompassHandler.gotoDirection == Handle_Controller.Directions.Right)
        {
            Debug.Log("y_worked");
            move = new Vector3(0, change);
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        autosave_timer += Time.deltaTime;
        if(autosave_timer > 500)
        {
            PlayerData.SaveConfig();
        }
        moveVector *= 0.5f * Time.deltaTime;
        if (controller.isGrounded == false)
        {
            //Add our gravity Vecotr
            moveVector += Physics.gravity;
        }
        if (!Application.isMobilePlatform && CompassHandler.gotoDirection == Handle_Controller.Directions.Down ^ CompassHandler.gotoDirection == Handle_Controller.Directions.Up)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }
        if (!Application.isMobilePlatform && CompassHandler.gotoDirection == Handle_Controller.Directions.Left ^ CompassHandler.gotoDirection == Handle_Controller.Directions.Right)
        {
            move = new Vector3(0, Input.GetAxis("Vertical"), 0);
        }
        //Apply our move Vector , remeber to multiply by Time.delta
        controller.Move((moveVector + (move * Speed)) * Time.deltaTime );
        move = Vector3.zero;
    }
}
