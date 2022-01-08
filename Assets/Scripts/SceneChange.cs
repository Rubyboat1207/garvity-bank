using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange
{
    public static void SetScene(string ID)
    {
        SceneManager.LoadSceneAsync(SceneManager.GetSceneByName(ID).buildIndex);
    }
}
