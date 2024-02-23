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
   
       
       float distanceBetween=  Vector2.Distance(gameObject.transform.position, Controller.SelectedPlayer.transform.position);
         //   Vector2 normalized = (((Vector2)Controller.SelectedPlayer.transform.position-(Vector2)goalKeeperBody.transform.position)).normalized; Is this still needed?
            if (distanceBetween > 1.5f)
            {
                goalKeeperBody.transform.position = Vector3.MoveTowards(gameObject.transform.position, Controller.SelectedPlayer.transform.position, distanceBetween / 4);
            }
        }
    }
}
