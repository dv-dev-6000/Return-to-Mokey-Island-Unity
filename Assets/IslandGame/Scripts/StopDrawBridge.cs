using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDrawBridge : MonoBehaviour
{
    public GameObject bridge;
    public LowerDrawBridge lowerScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bridge")
        {
            lowerScript.moveIt = false;
        }
    }
}
