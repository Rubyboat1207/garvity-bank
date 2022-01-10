using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField]
    int buildIndex;

    public void ChangeScene()
    {
        SceneManager.LoadScene(buildIndex);
    }
}
