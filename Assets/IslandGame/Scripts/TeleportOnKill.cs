using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnKill : MonoBehaviour
{
    public Transform destination;
    public GameObject target;
    [SerializeField] AudioSource splashSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target.transform.position = destination.position;
            target.transform.rotation = destination.rotation;
            splashSFX.Play();
        }
    }
}
