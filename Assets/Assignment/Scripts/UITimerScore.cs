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
    public Slider slider;
    public TextMeshProUGUI score;
    public TextMeshProUGUI gameOver;
    public float points;
    float timer = 10;
    bool increment = false;
 
    public void Update ()
    {
       
        timer -= 1.5f * Time.deltaTime;
        slider.value = timer;
        print(timer);
        if(timer <= 0)
        {
            
            SendMessage("LoadScene");
        }
        if (increment == true)
        {
            timer += 1;
            slider.value = timer;
            increment = false;
        }
        }
        public void TimerReset()
    {
        increment = true;
        
    }

   public void increasePoints(float adding)
    {
        points +=adding;
        score.text = points.ToString();
    }
}
