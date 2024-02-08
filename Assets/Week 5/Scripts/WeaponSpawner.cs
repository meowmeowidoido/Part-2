using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponSpawner : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject weaponSpawn;
    public Vector2 spawnPoint;
    private void Start()
    {
        spawnPoint = transform.position;
    }
  
    public void spawnAxe()
    {
        Instantiate(weaponSpawn, spawnPoint, transform.rotation);
    }
}
