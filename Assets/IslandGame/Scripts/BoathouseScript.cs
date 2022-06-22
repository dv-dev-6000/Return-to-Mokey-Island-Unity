using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoathouseScript : MonoBehaviour
{
    private bool inZone;
    public GM_Script gm;

    // Start is called before the first frame update
    void Start()
    {
        inZone = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && inZone)
        {
            if (gm.gotKey)
            {
                //gm.promptText.text = "Great Stuff, You Win!";
                gm.isEnd = true;
            }
            else
            {
                gm.promptText.text = "It's Locked! You need to find the key!";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            gm.promptText.text = "left click to access the Boathouse";
            inZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gm.promptText.text = " ";
            inZone = false;
        }
    }
}
