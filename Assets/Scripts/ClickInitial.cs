using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickInitial : MonoBehaviour
{
    //loads the game scene when clicked
    void OnMouseDown()
    {
        SceneManager.LoadScene("Game");
        
    } 
}
