using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoustacheHandler : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>())
        {
            transform.SetParent(Player.transform);
            transform.localPosition = new Vector3(0, 0, -2);
            transform.rotation = Quaternion.Euler(0,0,0);
            GameObject.Destroy(this);
        }
    }
}
