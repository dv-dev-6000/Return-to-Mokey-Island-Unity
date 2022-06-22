using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigSiteScript : MonoBehaviour
{
    public GameObject xMarker;
    public GM_Script gm;
    [SerializeField] AudioSource collectSFX;
    private bool revealed, dugOut, inZone;

    // Start is called before the first frame update
    void Start()
    {
        xMarker.SetActive(false);
        revealed = false;
        dugOut = false;
        inZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gotMap && !revealed)
        {
            xMarker.SetActive(true);
            revealed = true;
        }

        

        if (Input.GetMouseButtonDown(0) && !dugOut && inZone)
        {
            if (gm.gotSpade && gm.gotMap)
            {
                //if (gm.gemsFound < 7)             ** Now all dig sites only give gems, the key is gained from trade 
                //{
                //    gm.gemsFound++;
                //}
                //else
                //{
                //    gm.gotKey = true;
                //}
                gm.gemsFound++;

                dugOut = true;
                xMarker.SetActive(false);
                gm.promptText.text = " ";
                collectSFX.Play();
            }
            else if (gm.gotMap)
            {
                gm.promptText.text = "Get the spade to dig here!";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            if (revealed && !dugOut)
            {
                gm.promptText.text = "Left Click To Search Dig Site!";
            }

            inZone = true;
            print("Click mouse to dig...");

            //Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (revealed)
            {
                gm.promptText.text = " ";
            }

            inZone = false;
        }
    }
}
