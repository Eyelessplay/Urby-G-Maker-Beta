using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public string sceneName;
    public bool changeScene;

    private void Update()
    {
        if(changeScene)
        {
            SceneManager.LoadScene(sceneName);
        }
        
    }
}
