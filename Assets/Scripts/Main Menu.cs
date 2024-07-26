using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string sceneToLoad; // The name of the scene to reload
    public void Play_cut()
    {
        SceneManager.LoadScene(1);
    }

    public void Play_game()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Nextlevel()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
