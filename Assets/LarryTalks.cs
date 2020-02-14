using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarryTalks : MonoBehaviour
{
    [SerializeField]
    Canvas messageCanvas;
    // Start is called before the first frame update
    void Start()
    {
        messageCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TurnOnMessage();

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TurnOffMessage();

        }
    }

    public void TurnOnMessage()
    {
        messageCanvas.enabled = true;
    }
    public void TurnOffMessage()
    {
        messageCanvas.enabled = false;
    }
    
}
