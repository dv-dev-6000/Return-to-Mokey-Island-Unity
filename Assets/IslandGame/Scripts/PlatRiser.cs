using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatRiser : MonoBehaviour
{
    public GM_Script gm;
    [SerializeField] bool isButtonActivated;
    [SerializeField] int linkedButtonID;
    public float speed, maxHeight;

    private bool engage;
    public float startPosY;
    

    // Start is called before the first frame update
    void Start()
    {
        engage = false;
        startPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (engage && transform.position.y < maxHeight)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (!engage && transform.position.y > startPosY)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (isButtonActivated && gm.buttonsPressed[linkedButtonID])
        {
            engage = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isButtonActivated)
        {
            engage = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !isButtonActivated)
        {
            engage = false;
        }
    }
}
