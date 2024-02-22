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
        //if the player presses space, load the next scene
        if(Input.GetKeyUp(KeyCode.Space)) {
            LoadScene();
        }
    }
    public void LoadScene()
    {
        //gets the index of the active scene manager and adds one to it so that it will move to the next scene
       int  startingScreen= SceneManager.GetActiveScene().buildIndex;
       int nextScene =+ (startingScreen + 1) % SceneManager.sceneCountInBuildSettings;
        if (startingScreen == 6)//if the startingscreen is at the scene with the 6th index it will go back one scene
                //this is for resetting after a game over.
        {
            nextScene=+(startingScreen-1)%SceneManager.sceneCountInBuildSettings;//goes back to the previous index of the scene count
        }
        //loads the next scene
        SceneManager.LoadScene(nextScene);
    }
}
