using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 0.5f;
    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //checks the current scene 
        int nextSceneIndex = currentSceneIndex + 1; 

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings) //if the current scene is the same as the total number of scenes we have, then we reset index back to 0 
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
