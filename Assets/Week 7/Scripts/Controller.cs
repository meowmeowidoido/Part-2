using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;

public class Controller : MonoBehaviour
{
    
    // Start is called before the first frame update
   
       public static FootballerPlayer SelectedPlayer {  get; private set; }

    public static void SetSelectedPlayer(FootballerPlayer player)
    {
        if (SelectedPlayer != null)
        {
            SelectedPlayer.Selected(false);
        }

        SelectedPlayer = player;
        SelectedPlayer.Selected(true);
    }
    

    
}
