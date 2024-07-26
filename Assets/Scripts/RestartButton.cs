using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public GameObject winScreen;
    public string sceneToLoad; // The name of the scene to reload

    private void Start()
    {
        // Add a listener to the button's onClick event
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        winScreen.SetActive(false);
        // Reload the current scene
        SceneManager.LoadScene(sceneToLoad);
        Time.timeScale = 1f; // Unpause the game
    }
}