using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMe : MonoBehaviour
{
    public GM_Script gm;
    [SerializeField] string id;
    [SerializeField] AudioSource collectSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        gm.addItem(id);
        Destroy(gameObject);
        collectSFX.Play();
    }
}
