using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class myFirstPlayer : MonoBehaviour
{
    Transform t;
    private int dir = 0;
    private float speedMod;
    // Start is called before the first frame update
    void Start()
    {
        speedMod = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedMod = 4f;
        }
        else
        {
            speedMod = 1f;
        }
        if (Input.GetKey("w")){
            dir = 1;

            transform.Translate(0, 0.125f*speedMod, 0);
        }
        if(Input.GetKey("a"))
        {
            dir = 2;
            transform.Translate(-0.125f*speedMod, 0, 0);

        }
        if (Input.GetKey("s"))
        {
            dir = 3;
            transform.Translate(0,-0.125f*speedMod, 0);

        }
        if (Input.GetKey("d"))
        {
            dir = 0;
            transform.Translate(0.125f*speedMod, 0, 0);

        }
        if (dir == 0)
        {

        }
    }

}
