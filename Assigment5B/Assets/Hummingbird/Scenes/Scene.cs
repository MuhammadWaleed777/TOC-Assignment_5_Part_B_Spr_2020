using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void sceneLoad(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void QuitGame(string name)
    {
        Application.Quit();
    }
}
