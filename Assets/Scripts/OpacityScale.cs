using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpacityScale : MonoBehaviour
{
   
    public Slider _slider;

    public static float opacityNumber = 1;
    
    
    // Update is called once per frame
    void Update()
    {
        opacityNumber= _slider.value;
        Debug.Log(opacityNumber);
    }
}
