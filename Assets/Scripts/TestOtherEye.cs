using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class TestOtherEye : MonoBehaviour
{
	// variable for button
    public Button testOtherEye;

	void Start () {

		// add click listener to the function
		testOtherEye.onClick.AddListener(TaskOnClick);
	}

	// function that handles button click
	void TaskOnClick(){

		// when clicked button go back to game initial to test the other eye
        
		if (ClientInfo.eyeField=="L"){
			ClientInfo.eyeField="R";
		SceneManager.LoadScene("Game-Initial");
		} else if (ClientInfo.eyeField=="R"){
			ClientInfo.eyeField="L";
			SceneManager.LoadScene("Game-Initial");
		}
    }
}
