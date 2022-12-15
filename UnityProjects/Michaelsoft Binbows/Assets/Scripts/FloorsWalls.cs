 using UnityEngine;
 using System.Collections;
 
 public class ColorChanger : MonoBehaviour {
 
     float duration = 1.5f;
     private float t = 0;
     bool isReset = false;
 
     void Update()
     {
         ColorChangerr();
     }
 
 
     void ColorChangerr()
     {
         if (this.tag == "Barrier")
         {
 
                 GetComponent<Renderer>().material.color = Color.Lerp(Color.green, Color.red, t);
 
                 if (t < 1){ 
                     t += Time.deltaTime/duration;
                 }
             
         }
             
     }
 }
 
