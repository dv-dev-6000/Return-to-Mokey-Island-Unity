using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePusher : MonoBehaviour
{
    public float speed, maxLimit, delay;

    private float currProgress;

    // Start is called before the first frame update
    void Start()
    {
        currProgress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            currProgress += speed * Time.deltaTime;

            if (currProgress >= maxLimit)
            {
                currProgress = maxLimit;
                speed = -speed;
            }
            else if (currProgress <= 0)
            {
                currProgress = 0;
                speed = -speed;
            }
        }
        
    }
}
