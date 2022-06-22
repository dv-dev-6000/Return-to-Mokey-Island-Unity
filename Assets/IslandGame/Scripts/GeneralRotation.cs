using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralRotation : MonoBehaviour
{
    [SerializeField] bool rotX, rotY, rotZ;
    [SerializeField] float rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotX)
        {
            transform.Rotate(Vector3.right, rotSpeed);
        }

        if (rotY)
        {
            transform.Rotate(Vector3.up, rotSpeed);
        }

        if (rotZ)
        {
            transform.Rotate(Vector3.forward, rotSpeed);
        }
    }
}
