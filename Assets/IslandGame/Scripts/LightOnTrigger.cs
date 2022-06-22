using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnTrigger : MonoBehaviour
{
    public Light light;
    public ParticleSystem parti;

    // Start is called before the first frame update
    void Start()
    {
        light.enabled = false;
        parti.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            light.enabled = true;
            parti.Play();

            // ADD SOUND
        }

    }
}
