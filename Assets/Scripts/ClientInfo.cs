using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using System.IO; 
using System; 
using System.Text; 

public class ClientInfo : MonoBehaviour
{
    // button, input field and text varibles
    public Button CheckDetails;
    public Button Continue;
    public TMP_InputField fullName, dateOfBirth, eye;
    public static string eyeField;
    public TMP_Text errorEye, errorDOB, errorName, contMsg;
    
    // adds a click listener
	void Start () {
        string filePath = getPath();
        Continue.enabled = false;
		CheckDetails.onClick.AddListener(TaskOnClick);
         StreamWriter writer = new StreamWriter(filePath, false);
        writer.Write("");
        writer.Close();
        filePath = Application.dataPath +"/results1.csv";
        writer = new StreamWriter(filePath, false);
        writer.Write("");
        writer.Close();
         filePath = Application.dataPath +"/results2.csv";
         writer = new StreamWriter(filePath, false);
        writer.Write("");
        writer.Close();
         filePath = Application.dataPath +"/results3.csv";
        writer = new StreamWriter(filePath, false);
        writer.Write("");
        writer.Close();
         filePath = Application.dataPath +"/results4.csv";
        writer = new StreamWriter(filePath, false);
        writer.Write("");
        writer.Close();
         filePath = Application.dataPath +"/results5.csv";
        writer = new StreamWriter(filePath, false);
        writer.Write("");
        writer.Close();
         filePath = Application.dataPath +"/results6.csv";
        writer = new StreamWriter(filePath, false);
        writer.Write("");
        writer.Close();
	}

    // function that handles button click
	void TaskOnClick(){

        // booleans to check if input fields are correct format initialise to false
        bool eyeCheck = false;
        bool dobCheck = false;
        
        // check input for eye
        if(eye.text == "L" || eye.text == "R"){

            // set boolean to true for the compare later
            eyeCheck = true;

            // remove the error message
            errorEye.text = "";
            eyeField=eye.text;
        }
        else{

            // display error message
            errorEye.text = "Please input L for left or R for right";
        }

        // Validate if a string is a valid date format using regex
        Regex validateDateRegex = new Regex("^[0-9]{1,2}\\/[0-9]{1,2}\\/[0-9]{4}$");
        if(validateDateRegex.IsMatch(dateOfBirth.text)){

            // set boolean to true for compare later
            dobCheck = true;

            // remove the error message
            errorDOB.text = "";
        }
        else{

            // display error message
            errorDOB.text = "Please enter a valid date";
        }
        // if both input fields are correct, switch to main menu
        if(eyeCheck == true && dobCheck == true){
            Continue.enabled = true;
            contMsg.text = "Press Continue";
        }
        else
        {
            //The continue button will be enabled when all the client info have been inputted
            Continue.enabled = false;
        }
    }
    
    string getPath() 
    { 
        return Application.dataPath + "/results.csv"; 
    } 
      
    
}
