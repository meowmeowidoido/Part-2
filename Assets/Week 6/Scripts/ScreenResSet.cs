using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResSet : MonoBehaviour
{
    // Start is called before the first frame update
    public int fWidth;
    public int fHeight;

    public void SetWidth(int nWidth )
    {
        fWidth = nWidth;
    }

    public void SetHeight(int nHeight )
    {
        fHeight = nHeight;
    }
    public void SetScreenRez()
    {
       Screen.SetResolution(fWidth, fHeight,false);
    }
}
