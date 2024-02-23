using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEditor;

public class GoalKeeperController : MonoBehaviour
{
    public Rigidbody2D goalKeeperBody;

    public float speed = 70f;
    // Update is called once per frame
  
    public void FixedUpdate()
    {
        if (Controller.SelectedPlayer != null) { 
       Vector2 selectedPlayer= Controller.SelectedPlayer.transform.position;
       
       float distanceBetween=  Vector2.Distance(gameObject.transform.position, Controller.SelectedPlayer.transform.position);
        Vector2 normalized = (((Vector2)Controller.SelectedPlayer.transform.position-(Vector2)goalKeeperBody.transform.position)).normalized;

           
            print(distanceBetween);
            if (distanceBetween >5.50)
            {
                goalKeeperBody.transform.position = ((Vector2)transform.position + (normalized*2.5f))*speed*Time.deltaTime;
            }
           else 
            {

                goalKeeperBody.transform.position = ((Vector2)transform.position + (normalized/2.5f) *speed*Time.deltaTime);
            }
        }
    }
}
