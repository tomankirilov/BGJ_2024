using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidescript : MonoBehaviour
{

     private bool ishidden = false;
      public GameObject playerObject; // Reference to the player object
    // Start is called before the first frame update

    void Start()
    {
         playerObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && ishidden == false)
        {
            playerObject.SetActive(true);
            ishidden = true;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.E) && ishidden == true)
            {
                playerObject.SetActive(false);
                ishidden = false;
            }
        }
    }
}
