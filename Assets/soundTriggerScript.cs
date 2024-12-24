using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundScript : MonoBehaviour
{
    
    public AudioSource audio; 
    public AudioClip clip; 

    void Update() 
    { 

        if(Input.GetKeyDown(KeyCode.A)) { 

            audio.PlayOneShot(clip); 

        } 

    } 

}
