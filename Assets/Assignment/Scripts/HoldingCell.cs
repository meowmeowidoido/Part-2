using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingCell : MonoBehaviour
{//variables and calling classes
   public AnimationCurve cell;
    SpriteRenderer cellRenderer;
    float timer;
    float interpolation;
    Color startColor;

    private void Start() {
        //referencing the spriterenderer
        cellRenderer = GetComponent<SpriteRenderer>();
        //startcolor is assigned the cellrenderer's color
        startColor = cellRenderer.color;
    }
    void Update()
    {
        timer += 0.3f *Time.deltaTime;//timer that increments by 0.5
      interpolation=  cell.Evaluate(timer);//interpolating the timer

        cellRenderer.color=Color.Lerp(startColor,Color.green,interpolation);//using lerp to make the color go from red to green
        if (timer > 1)//resets the timer so it loops
        {
            timer=0;
        }
     
    }
    //when the holding cell detects a game object
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null) {
            // if the collision does not equal null/if there is a collision with the trigger, then it will send a message to increasepoints function and timerreset

            SendMessage("increasePoints", 1, SendMessageOptions.DontRequireReceiver);
            //resets/increments the timer and sends a message so the function will do its thing!
            SendMessage("TimerReset", SendMessageOptions.DontRequireReceiver);

        }
    }
}
