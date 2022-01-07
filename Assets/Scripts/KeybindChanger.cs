using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeybindChanger : MonoBehaviour
{
    int Keybind_id = 0;
    TextMeshProUGUI CurrentBindText;
    public static bool ischangingKeybind = false;
    private void Start()
    {
        CurrentBindText.text = PlayerData.GetKeybindByID(Keybind_id).ToString();
    }

    public void ChangeBind()
    {
        
    }
}
