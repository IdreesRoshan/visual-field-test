using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO; 
using System; 
using System.Text; 
using UnityEngine.SceneManagement;

public class MovingTargets : MonoBehaviour
{
    
    static int count;
    private Vector3 m_pos;
    public Sprite newFixPoint;

    // boolean to check balloon movement
    public bool move = true;

    // variables for the distance 
    public float unitysize;
    public float unityx = 200;
    public float unityy = 100;
    //counter for amount of balloons popped
    public int popCounter=0; 
    private AudioSource audioS; 
    
    public static List<Vector3> Clicked = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        // leave this commented just in case any bugs appear later on
        /*
        Vector3 m_center = new Vector3(Screen.width / 2f, Screen.height / 2f, Camera.main.nearClipPlane);
        
        m_pos = Camera.main.ScreenToWorldPoint(m_center);
        m_pos.z = 0f;
        */
        string filePath = getPath();
        Debug.Log(getPath()); 
 
        this.GetComponent<SpriteRenderer>().color = new Color(1.0f,1.0f,1.0f,this.GetComponent<SpriteRenderer>().color.a*OpacityScale.opacityNumber);
        this.transform.localScale=new Vector3(this.transform.localScale.x*BalloonSize.scaleNumber,this.transform.localScale.y*BalloonSize.scaleNumber,this.transform.localScale.z*BalloonSize.scaleNumber);

       

    }

    private void FixedUpdate()
    {   //only move if balloon is not clicked
        //balloons move towards fixation point
        GameObject fixpoint = GameObject.FindGameObjectWithTag("Fixation Point");
        Vector3 fixpointpos = fixpoint.transform.position;
        
        if (move == true) {
            float s = 0.002f;
            transform.position = Vector3.Lerp(transform.position, fixpointpos, s);
        }
    }

    // This method will delete a clicked balloon, and turn it into a new fixation point. It also moves
    // all the other balloons back to their initial position

    void OnMouseDown()
    {   // Create an array to hold all of the objects that currentl exist
        GameObject[] obs = (GameObject[]) UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        Vector3 pos = ray.GetPoint(0);
        Vector3 fppos=new Vector3(0,0,0);
        move = false; // Set move to false to stop object from moving to center
        Clicked.Add(pos);  // Get the distance when clicked, returns the clicked balloons distance in console
        //get audio clip to be played when object is clicked 
        audioS = GetComponent<AudioSource>(); 
        audioS.Play(); 
        distance();
       
        string tag=gameObject.tag;
        // Make sure if user clicks fixation point, it does not get destroyed
        if(gameObject.tag == "Fixation Point")
            return;

        // Delete the previous fixation point
        foreach(GameObject ob in obs)
        {
            if(ob.tag == "Fixation Point"){
                fppos= ob.transform.position;
                Destroy(ob);
            }
                
        }
        Debug.Log(ClientInfo.eyeField);
        gameObject.tag = "Fixation Point"; // Change the clicked balloon's tag, so it becomes the new fixation point
        gameObject.GetComponent<SpriteRenderer>().sprite = newFixPoint; // Change the clicked balloon's sprite to the fixation point sprite
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f,1.0f,1.0f,1.0f); // Make sure opacity of fixation point is full
        gameObject.transform.localScale = new Vector3(0.05f,0.1f,1.0f); // Make sure scale of fixation point stays the same
        fppos=pos-fppos;

        // move all the balloons back to their initial positions
        resetPositionsC1(obs,pos, tag,fppos); 
        resetPositionsC2(obs,pos, tag,fppos);
        resetPositionsC3(obs,pos, tag,fppos);
    }

    // move all the balloons back to their initial position, based on the contour, C1 means contour 1
    void resetPositionsC1(GameObject[] obs, Vector3 pos, string gameTag, Vector3 fppos) {
        // Initialising the initial positions of all the balloons
        // Vector3 posB1 = new Vector3(-110,55,0)+pos;
        // Vector3 posB2 = new Vector3(0,55,10)+pos;
        // Vector3 posB3 = new Vector3(110,55,10)+pos;
        // Vector3 posB4 = new Vector3(110,-55,10)+pos;
        // Vector3 posB5 = new Vector3(0,-55,10)+pos;
        // Vector3 posB6 = new Vector3(-110,-55,10)+pos;
        Vector3 posB1 = new Vector3(-110,55,0)+(new Vector3(0,0,0)+pos);
        Vector3 posB2 = new Vector3(0,55,10)+(new Vector3(0,0,0)+pos);
        Vector3 posB3 = new Vector3(110,55,10)+(new Vector3(0,0,0)+pos);
        Vector3 posB4 = new Vector3(110,-55,10)+(new Vector3(0,0,0)+pos);
        Vector3 posB5 = new Vector3(0,-55,10)+(new Vector3(0,0,0)+pos);
        Vector3 posB6 = new Vector3(-110,-55,10)+(new Vector3(0,0,0)+pos);
         
        foreach(GameObject ob in obs)
        {
            Debug.Log(gameTag);
            Debug.Log(ob.tag);

            // check the balloon tag and reset its position
            if(ob.tag == "b1"){
                
                ob.transform.position = posB1;
                
            }
            else if(ob.tag == "b2"){
                
                ob.transform.position = posB2;
            }
            else if(ob.tag == "b3"){
                
                ob.transform.position = posB3;
            }
            else if(ob.tag == "b4"){
                
                ob.transform.position = posB4;
            }
            else if(ob.tag == "b5"){
               
                
                ob.transform.position = posB5;
            }
            else if(ob.tag == "b6"){
                
                ob.transform.position = posB6;
            } 
                
           

        }

        // Write to a csv file 
        if (ClientInfo.eyeField=="R"){
        switch(gameTag){
            case "b1":
                writeCSV(fppos,gameTag,1);
                break;
            case "b2":
                writeCSV(fppos,gameTag,1);
                break;
            case "b3":
                writeCSV(fppos,gameTag,1);
                break;
            case "b4":
                writeCSV(fppos,gameTag,1);
                break;
            case "b5":
                writeCSV(fppos,gameTag,1);
                break;
            case "b6":
                writeCSV(fppos,gameTag,1);
                break;
           }
        }else if(ClientInfo.eyeField=="L"){
            switch(gameTag){
            case "b1":
                writeCSV(fppos,gameTag,4);
                break;
            case "b2":
                writeCSV(fppos,gameTag,4);
                break;
            case "b3":
                writeCSV(fppos,gameTag,4);
                break;
            case "b4":
                writeCSV(fppos,gameTag,4);
                break;
            case "b5":
                writeCSV(fppos,gameTag,4);
                break;
            case "b6":
                writeCSV(fppos,gameTag,4);
                break;
           }
        }
        
        // if 18 balloons are clicked then first test is done 
        if(Clicked.Count==18)
        {
            // load the scene for other eye
            SceneManager.LoadScene("Test Other Eye");
            
        }

        // if 36 balloons are clicked then game is finished
        if(Clicked.Count==36)
        {
            SceneManager.LoadScene("Contour");
            
        }
    }

    // move all the balloons back to their initial position, based on the contour, C2 means contour 2
    void resetPositionsC2(GameObject[] obs,Vector3 pos, string gameTag,Vector3 fppos) {
        // Initialising the initial positions of all the balloons
        Vector3 posB1 = new Vector3(-140,85,10)+pos;
        Vector3 posB2 = new Vector3(0,85,10)+pos;
        Vector3 posB3 = new Vector3(140,85,10)+pos;
        Vector3 posB4 = new Vector3(140,-85,10)+pos;
        Vector3 posB5 = new Vector3(0,-85,10)+pos;
        Vector3 posB6 = new Vector3(-140,-85,10)+pos;
        //check tag write to CSV and reset their positions back
        foreach(GameObject ob in obs)
        {
            if(ob.tag == "b21"){
                
                ob.transform.position = posB1;
            }
            else if(ob.tag == "b22"){
                
                ob.transform.position = posB2;
            }
            else if(ob.tag == "b23"){
                
                ob.transform.position = posB3;
            }
            else if(ob.tag == "b24"){
               
                ob.transform.position = posB4;
            }
            else if(ob.tag == "b25"){
                
                ob.transform.position = posB5;
            }
            else if(ob.tag == "b26"){
                
                ob.transform.position = posB6;
            }
                //increase counter here
            popCounter++;
        }
        if(ClientInfo.eyeField=="R"){
         switch(gameTag){
            case "b21":
                writeCSV(fppos,gameTag,2);
                break;
            case "b22":
                writeCSV(fppos,gameTag,2);
                break;
            case "b23":
                writeCSV(fppos,gameTag,2);
                break;
            case "b24":
                writeCSV(fppos,gameTag,2);
                break;
            case "b25":
                writeCSV(fppos,gameTag,2);
                break;
            case "b26":
                writeCSV(fppos,gameTag,2);
                break;
           }
        }else if (ClientInfo.eyeField=="L"){
            switch(gameTag){
            case "b21":
                writeCSV(fppos,gameTag,5);
                break;
            case "b22":
                writeCSV(fppos,gameTag,5);
                break;
            case "b23":
                writeCSV(fppos,gameTag,5);
                break;
            case "b24":
                writeCSV(fppos,gameTag,5);
                break;
            case "b25":
                writeCSV(fppos,gameTag,5);
                break;
            case "b26":
                writeCSV(fppos,gameTag,5);
                break;
           }
        }
    }

    // move all the balloons back to their initial position, based on the contour, C2 means contour 2
    void resetPositionsC3(GameObject[] obs, Vector3 pos, string gameTag,Vector3 fppos) {
        // Initialising the initial positions of all the balloons
        Vector3 posB1 = new Vector3(-170,115,10)+pos;
        Vector3 posB2 = new Vector3(0,115,10)+pos;
        Vector3 posB3 = new Vector3(170,115,10)+pos;
        Vector3 posB4 = new Vector3(170,-115,10)+pos;
        Vector3 posB5 = new Vector3(0,-115,10)+pos;
        Vector3 posB6 = new Vector3(-170,-115,10)+pos;
         //Write to a CSV file and reset their positions
        foreach(GameObject ob in obs)
        {
            if(ob.tag == "b31"){
                
                ob.transform.position = posB1;
            }
            else if(ob.tag == "b32"){
                
                ob.transform.position = posB2;
            }
            else if(ob.tag == "b33"){
                
                ob.transform.position = posB3;
            }
            else if(ob.tag == "b34"){
                
                ob.transform.position = posB4;
            }
            else if(ob.tag == "b35"){
                
                ob.transform.position = posB5;
            }
            else if(ob.tag == "b36"){
                
                ob.transform.position = posB6;
            }
                //increase counter here
            popCounter++;
        }
        if (ClientInfo.eyeField=="R"){
        switch(gameTag){
            case "b31":
                writeCSV(fppos,gameTag,3);
                break;
            case "b32":
                writeCSV(fppos,gameTag,3);
                break;
            case "b33":
                writeCSV(fppos,gameTag,3);
                break;
            case "b34":
                writeCSV(fppos,gameTag,3);
                break;
            case "b35":
                writeCSV(fppos,gameTag,3);
                break;
            case "b36":
                writeCSV(fppos,gameTag,3);
                break;
           }
        }else if(ClientInfo.eyeField=="L"){
            switch(gameTag){
            case "b31":
                writeCSV(fppos,gameTag,6);
                break;
            case "b32":
                writeCSV(fppos,gameTag,6);
                break;
            case "b33":
                writeCSV(fppos,gameTag,6);
                break;
            case "b34":
                writeCSV(fppos,gameTag,6);
                break;
            case "b35":
                writeCSV(fppos,gameTag,6);
                break;
            case "b36":
                writeCSV(fppos,gameTag,6);
                break;
           }
        }
    }
    
    // calculates the distance
    void calcUnitySize()
    {
        unitysize = Mathf.Sqrt((unityx * unityx) + (unityy * unityy));
    }
    // This method will return the distance of the clicked balloon relative to centre
    void distance() {
 
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        Plane plane = new Plane (Vector3.forward, transform.position);
        float dist = 0;
        Vector3 mousePos=Input.mousePosition;
        GameObject fixpoint = GameObject.FindGameObjectWithTag("Fixation Point");
        
        Vector3 fixpointpos = fixpoint.transform.position;
        
        // float mousePosX=ray.transform.x- fixpointpos.x;
        // float mousePosY=ray.transform.y- fixpointpos.y;
        // Debug.Log(mousePosX);
        // Debug.Log(mousePosY);
        // Debug.Log(fixpointpos);
        // Debug.Log(mousePos);
        
        if (plane.Raycast(ray, out dist)) {
            Vector3 pos = ray.GetPoint(dist);
        //    / Debug.Log (pos);
            float x= pos.x-fixpointpos.x;
            float y=pos.y-fixpointpos.y;
            print("The x coordinate is :" +x);
            print("The y coordinate is :"+y); 
            print("The angle is" + angle(x,y));
            
            count++;
            Debug.Log("This is the count returned: "+count);
            
            float distance = Vector2.Distance (fixpointpos, pos);
            print("The distance between the points is :" + distance);
        }
    } 
    
    // calculate the angle balloons clicked
    float angle(float x, float y)
    {
        float angle = Mathf.Atan(y/x);
        angle = Mathf.Abs(angle * (180/Mathf.PI));
        return angle;
    }
    
     void readCSV() { 

         //Loading the dataset from Unity's Resources folder 
        var dataset = Resources.Load<TextAsset>("results"); 
        //Splitting the dataset in the end of line 
        var dataLines = dataset.text.Split('\n'); 
        //Iterating through the split dataset in order to spli into rows 
        for(int i = 0; i < dataLines.Length; i++) {
            var data = dataLines[i].Split(',');
            for(int d = 0; d < data.Length; d++) {
                Debug.Log(data[d]); // this shows split sequential data that is column-first, then row 
            }
        }

    } 

    string getPath() 
    { 
        return Application.dataPath + "/results.csv"; 
    } 
      

    void writeCSV(Vector3 pos, string gameTag, int contour) { 

        string filePath=getPath();
        Debug.Log(gameTag); 
        if(contour==1){
            filePath = Application.dataPath +"/results1.csv";
        }else if(contour==2){
            filePath = Application.dataPath +"/results2.csv";
        }else if(contour ==3){
            filePath = Application.dataPath +"/results3.csv";
        }else 

        switch(contour){
            case 1:
                filePath = Application.dataPath +"/results1.csv";
                break;
            case 2:
                filePath = Application.dataPath +"/results2.csv";
                break;
            case 3:
                filePath = Application.dataPath +"/results3.csv";
                break;
            case 4:
                filePath = Application.dataPath +"/results4.csv";
                break;
            case 5:
                filePath = Application.dataPath +"/results5.csv";
                break;
            case 6:
                filePath = Application.dataPath +"/results6.csv";
                break;
        }
        StreamWriter writer = new StreamWriter(filePath, true); 

        // for (int i = 0; i < xValues.Count; i++)
        // {
 
            writer.Write(Convert.ToString(pos));
            writer.Write(",");
            if (gameTag=="b1"||gameTag=="b21"||gameTag=="b31"){
                writer.Write("0");
            } else if (gameTag=="b2"||gameTag=="b22"||gameTag=="b32"){
                writer.Write("1");
            }
            else if (gameTag=="b3"||gameTag=="b23"||gameTag=="b33"){
                writer.Write("2");
            }
            else if (gameTag=="b4"||gameTag=="b24"||gameTag=="b34"){
                writer.Write("3");
            }
            else if (gameTag=="b5"||gameTag=="b25"||gameTag=="b35"){
                writer.Write("4");
            }
            else if (gameTag=="b6"||gameTag=="b26"||gameTag=="b36"){
                writer.Write("5");
            }
            
            writer.Write("\n");
            
            Debug.Log("This is contour: "+contour);
            
        // } 

        // for (int j = 0; j < yValues.Count; j++)
        // {
 
          
        // } 

        writer.Close(); 
        
    } 
    
    
        
}


