using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    // When the back button is pressed it will load up the main menu scene
    public void goBack(){ 
        SceneManager.LoadScene("Main Menu");
    }
}
