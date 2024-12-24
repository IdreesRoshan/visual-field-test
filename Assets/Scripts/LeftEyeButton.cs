using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class LeftEyeButton : MonoBehaviour
{
	// variable for button
    public Button LeftButton;

	void Start () {

		// add click listener to the function
		LeftButton.onClick.AddListener(TaskOnClick);
	}

	// function that handles button click
	void TaskOnClick(){

		// when clicked button go back to game initial to test the other eye
        SceneManager.LoadScene("ContourLeft");
		
    }
}
