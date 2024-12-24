using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//This class lets us change scene depending on which button was pressed
public class MainMenuScript : MonoBehaviour
{
    //Each function is assigned to a button on the main menu screen
    public void PlayButton()
    {
        SceneManager.LoadScene("Range");
    }

    //This function will end the program
    public void ExitButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void GoSettingsMenu()
    {
        SceneManager.LoadScene("settingspage");
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
