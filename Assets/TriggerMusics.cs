using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusics : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {if (other.tag == "MusicBox")
        {
            print("Music Trigger");
            audioSource.Pause();

        }
    }
}
