using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToNextScene()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Get the build index of the next scene
        int nextSceneBuildIndex = currentScene.buildIndex + 1;

        // Check if the next scene exists
        if (nextSceneBuildIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneBuildIndex);
        }
        else
        {
            Debug.Log("No next scene available!");
        }
    }
}
