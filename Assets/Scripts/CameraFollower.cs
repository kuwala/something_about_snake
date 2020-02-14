using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject target;
    public float size = 2f;
    private float zoomRate;
    public float moveSpeed = 3f;
    private bool follow;
    Vector3 nextPosition;
    Vector3 nextScale;
    // Start is called before the first frame update
    void Start()
    {

        zoomRate = 0.125f * 4;
        follow = true;

        Camera cam = gameObject.GetComponent<Camera>() as Camera;
        cam.enabled = true;
        nextPosition = transform.position;
        nextScale = transform.localScale;

        //If the Camera exists in the inspector, enable orthographic mode and change the size
        if (cam)
        {
            //This enables the orthographic mode
            cam.orthographic = true;
            //Set the size of the viewing volume you'd like the orthographic Camera to pick up (5)
            cam.orthographicSize = size;
            //Set the orthographic Camera Viewport size and position
            cam.rect = new Rect(0, 0, 1f, 1f);
        }
    }
   
    // Update is called once per frame
    void LateUpdate()
    {

        if(Input.GetKey("-"))
        {
            size -= zoomRate;
        }
        if (Input.GetKey("="))
        {
            size += zoomRate;
        }
        if (Input.GetKeyDown("0"))
        {
            follow = !follow;
        }


        Camera cam = gameObject.GetComponent<Camera>() as Camera;

        // zoom rate 96 , 128 somethings should happen.

        //If the Camera exists in the inspector, enable orthographic mode and change the size
        if (cam)
        {
            //This enables the orthographic mode
            cam.orthographic = true;
            //Set the size of the viewing volume you'd like the orthographic Camera to pick up (5)
            cam.orthographicSize = size;
            //Set the orthographic Camera Viewport size and position
            cam.rect = new Rect(0, 0, 1f, 1f);
        }
        //size += zoomRate;
        if(follow)
        {
            if(target != null)
            {
                Transform t = target.GetComponent<Transform>();
                nextPosition.x = t.position.x;
                nextPosition.y = t.position.y;
            }
            
        }
        if(target!= null)
        {
            transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * moveSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale, nextScale, Time.deltaTime * moveSpeed);
        }
        
        
    }
    public void SetStaticPosition(Transform t)
    {
        follow = false;
        nextPosition = t.position;
        nextScale = t.localScale; 
    }
    public void StartFollow()
    {
        follow = true;
    }
}
