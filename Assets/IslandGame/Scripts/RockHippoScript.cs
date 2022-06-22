using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHippoScript : MonoBehaviour
{
    [SerializeField] GM_Script gm;
    [SerializeField] AudioSource feedMe, getOff, findMore;

    private bool inZone;

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
            if (gm.gemsFound >= 8)
            {
                gm.promptText.text = "Oh my! such tasty gems. Take this key and leave me!";
                getOff.Play();
                feedMe.Stop();
                gm.gotKey = true;
                gm.gemsFound = 0;
            }
            else
            {
                gm.promptText.text = "You'll need to find more gems than that!";
                findMore.Play();
                feedMe.Stop();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inZone = true;
            gm.promptText.text = "click to feed Darnell gems!";
            feedMe.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inZone = false;
            gm.promptText.text = " ";
        }
    }
}
