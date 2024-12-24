using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonSize : MonoBehaviour
{
    public Slider _slider;

    public static float scaleNumber = 1;
    
    
    // Update is called once per frame
    void Update()
    {
        scaleNumber= _slider.value *0.3f;
        
    }
}
