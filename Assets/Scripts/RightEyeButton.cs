using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class RightEyeButton : MonoBehaviour
{
	// variable for button
    public Button RightButton;

	void Start () {

		// add click listener to the function
		RightButton.onClick.AddListener(TaskOnClick);
	}

	// function that handles button click
	void TaskOnClick(){

		// when clicked button go back to game initial to test the other eye
        SceneManager.LoadScene("Contour");
		
    }
}
