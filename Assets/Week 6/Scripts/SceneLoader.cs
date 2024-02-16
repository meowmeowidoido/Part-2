using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int nextSceneIndex;
    public int currentSceneIndex;
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        print(currentSceneIndex);
    }
   
    public void GetSceneChange(int sceneNumber)
     {
         nextSceneIndex = sceneNumber;
     }
    public void LoadNextScene()


    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex += (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(nextSceneIndex);
    }
}
