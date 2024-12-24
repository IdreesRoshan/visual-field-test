using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RangeFinder : MonoBehaviour
{
    public int port = 5;
    private PercyPlugin _percy;
    public Button ContinueR;
    public TMP_Text Check;

    // Start is called before the first frame update, it sets the range checker to empty, continue button is disabled and we create a 
    // PercyPlugin object which allows us to manipulate the range finder
    void Start()
    {
        Check.text = "";
        ContinueR.enabled = false;
        _percy = new PercyPlugin(port);
    }

    // Update is called once per frame
    void Update()
    {
        //If percy is not in registered tp the correct port that the range finder is in, it will not continue
        if (!_percy.NotNull)
            return;

        //Depending on the distance, it will tell you how to move and once you are in the right place, the continue button is enabled
        if((400 < _percy.mmGetDistance()) && (_percy.mmGetDistance() < 500))
        {
            Check.text = "Perfect! Press Continue";
            ContinueR.enabled = true;
        }
        else if(_percy.mmGetDistance() > 500)
        {
            Check.text = "Move in Closer";
            ContinueR.enabled = false;
        }
        else if (_percy.mmGetDistance() < 400)
        {
            Check.text = "Too Close!";
            ContinueR.enabled = false;
        }


    }

    //Function to change scene to the game initial scene
    public void moveToGame()
    {
        SceneManager.LoadScene("Game-Initial");
    }




}
