using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sammy : MonoBehaviour
{
    public float stepSize = 0.3f;
    public int framesPerStep = 10;
    private int frames;
    // Start is called before the first frame update
    void Start()
    {
        frames = 0;
    }

    // Update is called once per frame
    void Update()
    {
        frames += 1;
        if((frames % framesPerStep) == 0)
        {
            //move the sammy
            Vector3 pos = transform.position;
            float xStep = Random.Range(-1f, 1f) * stepSize;
            float yStep = Random.Range(-1f, 1f) * stepSize;
            transform.position = new Vector3(pos.x + xStep, pos.y + yStep, pos.z);
        }
        //
    }
}
