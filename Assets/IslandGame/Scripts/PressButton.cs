using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    [SerializeField] int buttonID;
    [SerializeField] GameObject buttonOff, buttonOn;
    public GM_Script gm;

    private bool inZone, buttonPressed;

    // Start is called before the first frame update
    void Start()
    {
        buttonOn.SetActive(false);
        inZone = false;
        buttonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inZone && Input.GetMouseButtonDown(0) && !buttonPressed)
        {
            buttonOn.SetActive(true);
            gm.buttonsPressed[buttonID] = true;
            buttonPressed = true;
            gm.promptText.text = " ";
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            inZone = true;

            if (!buttonPressed)
            {
                gm.promptText.text = "left click to press button";
            }
            //Destroy(gameObject);
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
