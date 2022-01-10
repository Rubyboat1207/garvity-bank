using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    string original_text;

    void Start()
    {
        original_text = GetComponent<TextMeshProUGUI>().text;
    }
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = original_text + " " + PlayerData.DeathCount;
    }
}
