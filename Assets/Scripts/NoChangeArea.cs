using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RunOnCollide))]
public class NoChangeArea : MonoBehaviour
{
    public Handle_Controller.Directions direction;
    int direction_id;
    public Color[] DirectionColors = {new Color(1,0,0),new Color(0,1,0),new Color(1, 1, 0), new Color(1, 165/255, 0) };
    public Material editableMaterial;
    public float speed = 2;
    Vector2 offset;
    [SerializeField]
    Vector2 Tiling_base;
    private void Start()
    {
        editableMaterial = GetComponent<Renderer>().material;
        switch (direction)
        {
            case Handle_Controller.Directions.Up : direction_id = 0; offset = new Vector2(0,1); break;
            case Handle_Controller.Directions.Down : direction_id = 1; offset = new Vector2(0, -1); break;
            case Handle_Controller.Directions.Left : direction_id = 2; offset = new Vector2(-1, 0); editableMaterial.mainTextureScale = new Vector2(Tiling_base.x, Tiling_base.y); break;
            case Handle_Controller.Directions.Right : direction_id = 3; offset = new Vector2(1, 0); editableMaterial.mainTextureScale = new Vector2(-Tiling_base.x, Tiling_base.y); break;
            default: direction_id = -1; break;
        }
        editableMaterial.color = DirectionColors[direction_id];
        GetComponent<Renderer>().material = editableMaterial;
    }
    private void Update()
    {
        editableMaterial.mainTextureOffset += offset * new Vector2(speed, speed) * Time.deltaTime;
    }
}
