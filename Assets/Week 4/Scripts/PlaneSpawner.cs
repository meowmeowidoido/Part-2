using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    float timer;
    float randomPosition;
    public GameObject plane;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        print(timer);
        if (timer >3)
        {
            Instantiate(plane);
            timer = 0;
        }
    }
}
