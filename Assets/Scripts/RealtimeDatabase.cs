using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class RealtimeDatabase : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField DOBInput;
    public TMP_InputField hospitalNumInput;
    public TMP_InputField eyeInput;

    private string clientID;
    private DatabaseReference reference;

    void Start()
    {
        //This will create a private databse reference so that we know where to get our data from
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    //This function will create a new client where we store all the data inputted, we then store this data into the firebase database
    public void CreateClient()
    {
        //We create a new instance of our client with all the necessary inforation we need
        Client newClient = new Client(nameInput.text, DOBInput.text, hospitalNumInput.text, eyeInput.text);

        //This will conver the Client data into Json data as a string
        string json = JsonUtility.ToJson(newClient);
        
        //Using that json string, we will store that information using a unique ID into the database using the databse reference 
        reference.Child("client" + System.Guid.NewGuid()).SetRawJsonValueAsync(json);
    }

    //When this function is called we willl move to the main menu scene
    public void moveToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }


}
