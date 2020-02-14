using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDoor : MonoBehaviour
{
    public bool entered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (entered)
        {
            transform.localScale = new Vector3(16f, 16f, 16f);
        }
        else
        {
            transform.localScale = new Vector3(8f, 8f, 8f);
        }

    }
}
