using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour
{
    private int sceneIndex = 0;

    public void RestartScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
    
    
}
