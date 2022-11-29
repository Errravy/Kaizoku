using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    int currentScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void menuButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void NextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }
    public void quit()
    {
        Application.Quit();  
    }
    public void restart()
    {
        SceneManager.LoadScene(currentScene + 1);
    }
}
