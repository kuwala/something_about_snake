using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snappyCamMover : MonoBehaviour
{
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cam != null)
        {
            float difx;
            difx = transform.position.x - cam.transform.position.x;
            float dify;
            dify = transform.position.y - cam.transform.position.y;
            if (difx > 5)
            {
                cam.transform.position = new Vector3(cam.transform.position.x + 12, cam.transform.position.y, cam.transform.position.z);
            }
            if (difx < -5)
            {
                cam.transform.position = new Vector3(cam.transform.position.x -12, cam.transform.position.y, cam.transform.position.z);
            }
            if (dify > 5)
            {
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 12, cam.transform.position.z);
            }
            if (dify < -5)
            {
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - 12, cam.transform.position.z);
            }
        }
    }



}
