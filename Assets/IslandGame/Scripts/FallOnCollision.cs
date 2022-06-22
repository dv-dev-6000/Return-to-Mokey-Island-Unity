using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOnCollision : MonoBehaviour
{
    public Rigidbody platform;
    private Vector3 startPos;
    private Quaternion startRot;
    [SerializeField] AudioSource breakSFX;
    public bool isTriggered;
    private float delayTimer;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;

        platform = GetComponent<Rigidbody>();

        resetObject();
    }

    void resetObject()
    {
        isTriggered = false;
        platform.isKinematic = true;
        delayTimer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            delayTimer -= 1 * Time.deltaTime;
        }

        if (delayTimer <= 0)
        {
            if (platform.isKinematic)
            {
                platform.isKinematic = false;
            }
            
            if (delayTimer < -15)
            {
                resetObject();
                transform.position = startPos;
                transform.rotation = startRot;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isTriggered)
        {
            isTriggered = true;
            breakSFX.Play();
        }
    }

}
