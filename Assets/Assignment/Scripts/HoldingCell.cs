using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingCell : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null) {

            SendMessage("increasePoints", 1, SendMessageOptions.DontRequireReceiver);

            SendMessage("TimerReset", SendMessageOptions.DontRequireReceiver);

        }
    }
}
