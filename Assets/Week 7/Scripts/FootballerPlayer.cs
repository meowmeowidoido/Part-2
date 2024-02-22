using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using Unity.PlasticSCM.Editor.WebApi;

public class FootballerPlayer : MonoBehaviour
{
    SpriteRenderer footballerSprite;
  

    // Start is called before the first frame update
    void Start()
    {
       
        footballerSprite=GetComponent<SpriteRenderer>();
        footballerSprite.color = Color.red;
        
    }

   
    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }

    public void Selected(bool isSelected)
    {
        
        if (isSelected==true)
        {
            footballerSprite.color = Color.blue;
        }
        if(isSelected==false)
        {
            footballerSprite.color = Color.red; 
        }
    }
}
