using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerDrawBridge : MonoBehaviour
{
    public GM_Script gm;
    public Transform origin;
    public float speed;
    [SerializeField] int linkedButtonID;
    [SerializeField] GameObject miniCam;

    public bool moveIt, triggered;

    // Start is called before the first frame update
    void Start()
    {
        moveIt = false;
        triggered = false;
        miniCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.buttonsPressed[linkedButtonID] && !triggered)
        {
            moveIt = true;
            triggered = true;
        }

        if (moveIt)
        {
            this.transform.RotateAround(origin.position, transform.forward, speed * Time.deltaTime);
            miniCam.SetActive(true);
        }
        else { miniCam.SetActive(false); }
    }
}
