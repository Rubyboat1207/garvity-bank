using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoChangeArea : MonoBehaviour
{
    public Handle_Controller.Directions direction;
    int direction_id;
    public Color[] DirectionColors = {new Color(1,0,0),new Color(0,1,0),new Color(1, 1, 0), new Color(1, 165/255, 0) };
    public Material editableMaterial;
    public float speed = 2;

    private void Start()
    {
        switch(direction)
        {
            case Handle_Controller.Directions.Up : direction_id = 0; break;
            case Handle_Controller.Directions.Down : direction_id = 1; break;
            case Handle_Controller.Directions.Left : direction_id = 2; break;
            case Handle_Controller.Directions.Right : direction_id = 3; break;
            default: direction_id = -1; break;
        }
        editableMaterial = GetComponent<Renderer>().material;
        editableMaterial.color = DirectionColors[direction_id];
        GetComponent<Renderer>().material = editableMaterial;
    }
    private void Update()
    {
        editableMaterial.mainTextureOffset += new Vector2(speed, speed) * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>())
        {
            CompassHandler.DisableDirection(direction);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            CompassHandler.EnableDirection(direction);
        }
    }
}
