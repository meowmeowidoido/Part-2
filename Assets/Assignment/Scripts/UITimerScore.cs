using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;
public class UITimerScore : MonoBehaviour
{
    //calling classes and initializing variables
    public Slider slider;
    public TextMeshProUGUI score;
    public float points;
    float timer = 10;
    bool increment = false;
 
    public void Update ()
    {
       //timer, that goes down and makes the slider UI go down as well
        timer -= 1.5f * Time.deltaTime;
        slider.value = timer;
        print(timer);
        //if the timer is at 0 load the game over scene
        if(timer <= 0)
        {
            
            SendMessage("LoadScene");
        }
        //if increment is true, add +1 to the timer and put increment back at false
        if (increment == true)
        {
            timer += 1;
            slider.value = timer;
            increment = false;
        }
        }
    //function for resetting time
        public void TimerReset()
    {
        //when it is called increment becomes true and allows the slider/timer to increment
        increment = true;
        
    }

    //function for increasing points
   public void increasePoints(float adding)
    {//when it receives a message or is called the function can then increment points and put it into the UI text.
        points +=adding;
        score.text = points.ToString();
    }
}
