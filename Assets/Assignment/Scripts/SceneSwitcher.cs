using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{ 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) {
            LoadScene();
        }
    }
    private void LoadScene()
    {
       int  startingScreen= SceneManager.GetActiveScene().buildIndex;
       int nextScene =+ (startingScreen + 1) % SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(nextScene);
    }
}
