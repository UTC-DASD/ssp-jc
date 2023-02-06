using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour{


    public GameObject pauseButton, pausePanel;

    public void OnPause()
    {
        Time.timescale = 0;
    } 

    public void OnUnPause()
    {
        Time.timescale = 1;
    }
   
}
