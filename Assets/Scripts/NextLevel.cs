using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to reload

    private void Start()
    {
        // Add a listener to the button's onClick event
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
