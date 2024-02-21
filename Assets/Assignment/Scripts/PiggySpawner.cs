using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject piggies;
    float timer = 0;
    void Update()
    {
       
        timer += Time.deltaTime;
        if (timer > 1)
        {
            int ran1 = Random.Range(-7, 5);
            int ran2 = Random.Range(-3, 3);
            Vector2 randomizedSpawner=new Vector2(ran1,ran2);
            piggies.transform.position = randomizedSpawner;
            Instantiate(piggies);
            timer = 0;
            print(timer);
        }
    }
}
