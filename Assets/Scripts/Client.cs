using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class will allow us to create an object where we can save data the clients data
public class Client
{
    public string name;
    public string DOB;
    public string hospitalNum;
    public string eye;


    //This is the constructor, it will store all the information inputted in the client info scene
    public Client(string name, string DOB, string hospitalNum, string eye)
    {
        this.name = name;
        this.DOB = DOB;
        this.hospitalNum = hospitalNum;
        this.eye = eye;
    }
}
