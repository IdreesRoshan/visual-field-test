using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class ContourGraph : MonoBehaviour
{
    Vector3[] Clicked=new Vector3[6];
    Vector3[] Clicked2=new Vector3[6];
    Vector3[] Clicked3=new Vector3[6];

    // Start is called before the first frame update
    void Start()
    {
     readCSV(1);
     readCSV(2);
     readCSV(3);
    ContourDrawing();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void readCSV(int contour) { 
        
         //Loading the dataset from Unity's Resources folder 
          string[] dataLines = File.ReadAllLines(getPath());
        //Splitting the dataset in the end of line 
        switch (contour){
            case 1:
               dataLines = File.ReadAllLines(Application.dataPath + "/results1.csv");
               break;
            case 2:
               dataLines = File.ReadAllLines(Application.dataPath + "/results2.csv");
                break;
            case 3:
                dataLines = File.ReadAllLines(Application.dataPath + "/results3.csv");
                break;
        }
        
        //Iterating through the split dataset in order to spli into rows 
        
        for(int q = 0; q < 6;q++){
            Debug.Log(q+dataLines[q]);
            string[] lineData =(dataLines[q].Trim()).Split(","[0]);
            Debug.Log("Reading");
            
            if (lineData[0].StartsWith ("(") && lineData[2].EndsWith (")")) {
             lineData[0] = lineData[0].Substring(1, lineData[0].Length-2);
             lineData[2]= lineData[2].Substring(1,lineData[2].Length-2);
         }
         string[] sArray = lineData[0].Split(',');
         Debug.Log(lineData[0]);
         Debug.Log(lineData[1]);
         Debug.Log(lineData[2]);
          Vector3 result = new Vector3(
             float.Parse(lineData[0]),
             float.Parse(lineData[1]),
             float.Parse(lineData[2]));
        switch (contour){
            case 1:
               Clicked[int.Parse(lineData[3])]=result;
               break;
            case 2:
                Clicked2[int.Parse(lineData[3])]=result;
                break;
            case 3:
                Clicked3[int.Parse(lineData[3])]=result;
                break;
        }
        
        }
            // for(int d = 0; d < Clicked.Count; d++) {
            //     Debug.Log(Clicked[d]); // this shows split sequential data that is column-first, then row 
            // }
    

    } 

     
    void ContourDrawing(){
        GameObject[] dots = (GameObject[]) UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
        Debug.Log("AAAAAAAA");
        foreach(GameObject i in dots){
            //Debug.Log(i.tag);
            switch(i.tag){
                case "c1":
                    i.transform.position=Clicked[0];
                    break;
                case "c2":
                    i.transform.position=Clicked[1];
                    break;
                case "c3":
                    i.transform.position=Clicked[2];
                    break;
                case "c4":
                    i.transform.position=Clicked[3];
                    break;
                case "c5":
                    i.transform.position=Clicked[4];
                    break;
                case "c6":
                    i.transform.position=Clicked[5];
                    break;
                case "c21":
                    i.transform.position=Clicked2[0];
                    break;
                case "c22":
                    i.transform.position=Clicked2[1];
                    break;
                case "c23":
                    i.transform.position=Clicked2[2];
                    break;
                case "c24":
                    i.transform.position=Clicked2[3];
                    break;
                case "c25":
                    i.transform.position=Clicked2[4];
                    break;
                case "c26":
                    i.transform.position=Clicked2[5];
                    break;
                case "c31":
                    i.transform.position=Clicked3[0];
                    break;
                case "c32":
                    i.transform.position=Clicked3[1];
                    break;
                case "c33":
                    i.transform.position=Clicked3[2];
                    break;
                case "c34":
                    i.transform.position=Clicked3[3];
                    break;
                case "c35":
                    i.transform.position=Clicked3[4];
                    break;
                case "c36":
                    i.transform.position=Clicked3[5];
                    break;
                    
            }
        }
        distanceCalculator();
    }

    void distanceCalculator(){
        float minDist=200000;
        Vector3 nextDotPos=new Vector3(0,0,0);
        LineRenderer lineRenderer= new LineRenderer();
        
        GameObject[] dots = (GameObject[]) UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
        foreach(GameObject i in dots){
            minDist=200000;
            if(i.tag=="MainCamera"){
                continue;
            }
            lineRenderer=i.GetComponent<LineRenderer>();
           
            foreach(GameObject j in dots){
                if (i.tag=="c1"){
                    if(j.tag=="c2"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                }else if (i.tag=="c2"){
                    if(j.tag=="c3"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                }else if (i.tag=="c3"){
                    if(j.tag=="c4"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                }else if (i.tag=="c4"){
                    if(j.tag=="c5"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                    
                }else if (i.tag=="c5"){
                    if(j.tag=="c6"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                } else if(i.tag=="c6"){
                    if(j.tag=="c1"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                }if (i.tag=="c21"){
                    if(j.tag=="c22"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                }else if (i.tag=="c22"){
                    if(j.tag=="c23"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                }else if (i.tag=="c23"){
                    if(j.tag=="c24"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                }else if (i.tag=="c24"){
                    if(j.tag=="c25"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                    
                }else if (i.tag=="c25"){
                    if(j.tag=="c26"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                } else if(i.tag=="c26"){
                    if(j.tag=="c21"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                }if (i.tag=="c31"){
                    if(j.tag=="c32"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                }else if (i.tag=="c32"){
                    if(j.tag=="c33"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                }else if (i.tag=="c33"){
                    if(j.tag=="c34"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                }else if (i.tag=="c34"){
                    if(j.tag=="c35"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                    
                }else if (i.tag=="c35"){
                    if(j.tag=="c36"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                } else if(i.tag=="c36"){
                    if(j.tag=="c31"){
                        lineRenderer.SetPosition(0, i.transform.position);
                        lineRenderer.SetPosition(1, j.transform.position );
                    }
                }

            }
            

            
        }
    }
        
    //     }
    // public static Vector3 StringToVector3(string sVector)
    //  {
    //      // Remove the parentheses
    //      if (sVector.StartsWith ("(") && sVector.EndsWith (")")) {
    //          sVector = sVector.Substring(1, sVector.Length-2);
    //      }
 
    //      // split the items
    //      string[] sArray = sVector.Split(',');
    //     Debug.Log(sArray[0]);
    //     Debug.Log(sArray[1]);
    //     Debug.Log(sArray[2]);
    //      // store as a Vector3
    //      Vector3 result = new Vector3(
    //          float.Parse(sArray[0]),
    //          float.Parse(sArray[1]),
    //          float.Parse(sArray[2]));
 
    //      return result;
    //  }
     string getPath() 
    { 

        return Application.dataPath + "/results1.csv"; 

    } 
}
