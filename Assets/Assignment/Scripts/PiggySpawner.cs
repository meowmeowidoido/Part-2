using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    //object class for piggies 
    public GameObject piggies;
    float timer = 0;//timer variable
    void Update()
    {
       //incrementing timer
        timer += Time.deltaTime;
        if (timer > 0.5)//if timer is at 0.5 spawn a pig at a random location on the screen
        {
            //randomizes for vector points
            int ran1 = Random.Range(-7, 5);
            int ran2 = Random.Range(-3, 3);
            Vector2 randomizedSpawner=new Vector2(ran1,ran2);
            piggies.transform.position = randomizedSpawner;//sets the pigs transform position to that of the randomized numbers and transform x and y 
            Instantiate(piggies); //instantiates the pig
            timer = 0;//timer is set back to 0
            //print(timer); debugging
        }
    }
}
