using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class FootballerPlayer : MonoBehaviour
{
    SpriteRenderer footballerSprite;
  

    // Start is called before the first frame update
    void Start()
    {
       
        footballerSprite=GetComponent<SpriteRenderer>();
    }

   
    private void OnMouseDown()
    {
        Selected(true);
    }

    private void Selected(bool isSelected)
    {
        
        if (isSelected==true)
        {
            footballerSprite.color = Color.blue;
        }
        if(isSelected==false)
        {
            footballerSprite.color = Color.white;
        }
    }
}
