using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using Firebase.Extensions;


//This class is used for the login screen, it uses firebase to store and check the data inputted
public class AuthController : MonoBehaviour
{
    public TMP_Text emailInput, passwordInput;

    //This function deals with the email and the password input
    public void Login()
    {
        //Thia function will allow users to login, it will check the input fields for the email and password and respond depending on whether they are in the database or not
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(emailInput.text, passwordInput.text).ContinueWithOnMainThread((task => {

            //If the login process was cancelled it will do nothing
            if (task.IsCanceled)
            {
                return;
            }
            //IsFaulted will check if there were any errors and produce an error message
            if (task.IsFaulted)
            {
                //An error will throw and exception and produce an error message
                Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                //This function is responsible for printing out the error message in the console
                GetErrorMessage((AuthError)e.ErrorCode);

                return;
            }
            //If both email and password are within the datanbase it will login successully, change the scene and open the database on a separate web browser
            if (task.IsCompleted)
            {
                print("Login Successful");

                //This URL is where the firebase database is, we can see all the client info within this link
                Application.OpenURL("https://console.firebase.google.com/project/visual-field-test-d464e/database/visual-field-test-d464e-default-rtdb/data");

                //New scene is loaded here leading you to the client info page
                SceneManager.LoadScene("ClientInfo");
            }


        }));



    }

    //This function allows you to register a new user and stores the new email and password into the firebase database
    public void RegisterUser()
    {
        //This furebase function will create a new user and store it into the database
        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(emailInput.text, passwordInput.text).ContinueWith((task => {

            //If both email and password entries are empty, it will not do anything and it will ask the user to enter an email and password
            if(emailInput.text.Equals("") && passwordInput.text.Equals(""))
            {
                print("Please enter an email and password to register");
                return;
            }

            //If the task is cancelled nothing will happen
            if (task.IsCanceled)
            {
                return;
            }

            //If there is an error such as a weak password or missing email or password, an exception is thrown and and error message is produced
            if (task.IsFaulted)
            {
                Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorMessage((AuthError)e.ErrorCode);

                return;
            }

            //If everythning is correct, it will successfully create a new user in the firebase databse
            if (task.IsCompleted)
            {
                print("Registration Complete");
            }
            

       }));



    }

    //This function will print out any errors recognised by the firebase error system
    void GetErrorMessage(AuthError errorCode)
    {
        string msg = "";
        msg = errorCode.ToString();

        print(msg);
    }
    
}
