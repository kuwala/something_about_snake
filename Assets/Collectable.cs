using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioClip pickupSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            // play sound
            if (pickupSound != null)
            {
                print("soundExhisits");
                AudioSource.PlayClipAtPoint(pickupSound, transform.position, 1f);
                print("shoulda played");
            }
            print("picked up");
            Destroy(gameObject);
            
        }
    }
}
