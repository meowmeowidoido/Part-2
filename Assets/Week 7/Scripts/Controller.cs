using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;
using TMPro;

public class Controller : MonoBehaviour
{

    // Start is called before the first frame update
    public Slider chargeSlider;
    public TextMeshProUGUI scoreText;
    float chargeValue;
    public float maxCharge = 1;
    public static float ballScore;
    Vector2 direction;
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
    private void FixedUpdate()
    {
        if(direction!= Vector2.zero)
        {
            SelectedPlayer.Move(direction);
            direction=Vector2.zero;
            chargeValue = 0;
            chargeSlider.value= chargeValue;
        }
    }
    private void Update()
    {
        if (SelectedPlayer == null) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            chargeValue = 0;
            direction = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            chargeValue += Time.deltaTime;
            chargeSlider.value = chargeValue;
            chargeValue=Mathf.Clamp(chargeValue, 0, maxCharge);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)SelectedPlayer.transform.position).normalized*chargeValue;
           
        }
        scoreText.text= ballScore.ToString();
    }


}
