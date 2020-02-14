using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnakePlayerSmooth : MonoBehaviour
{

    Transform t;
    public int dir = 0;
    public int snakeLength;
    public GameObject tailPrefab;
    public Vector2 lastLocation;
    public Vector2 currentLocation;
    private readonly int framesPerTick = 4;
    public AudioSource audioSource;
    private int frames;
    public float moveSize = 4.0f;
    private bool ate;
    private List<Transform> tails;
    private int state;
    public GameObject snak;

    // Start is called before the first frame update
    void Start()
    {
        state = 1; // start on 2
        frames = 0;
        lastLocation = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
        currentLocation = lastLocation;
        ate = false;
        tails = new List<Transform>();

        //InvokeRepeating("Move", 0.2f, 0.2f);

        for (int i = 0; i < snakeLength; i++)
        {
            // make snake block
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject tail = Instantiate(tailPrefab, pos, Quaternion.identity);
            tails.Insert(0, tail.transform);
            //tail.transform.position = new Vector3(transform.position.x, transform.position.y +i *1.0f, transform.position.z);
        }
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if(state == 1) // active state
        {
            frames++;
            if (frames % framesPerTick == 0)
            //if (true)
            {
                DoInput();

                if (state == 1)
                {
                    Move();
                }

            }// tick update

        } else if(state == 2) // pause input state
        {
            dir = -1;
            Move();

        }

    } // end update

    public void DoInput()
    {
        dir = -1;
        if (Input.GetKey("w"))
        {
            dir = 1;
        }
        if (Input.GetKey("a"))
        {
            dir = 2;
        }
        if (Input.GetKey("s"))
        {
            dir = 3;
        }
        if (Input.GetKey("d"))
        {
            dir = 4;
        }
        if (Input.GetKey("o"))
        {
            Vector3 pos = new Vector3(transform.position.x+8, transform.position.y+8, transform.position.z);
            GameObject tail = Instantiate(snak, pos, Quaternion.identity);
            //tails.Insert(0, tail.transform);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Moved eat out 
        if(collision.tag == "Door")
        {
            collision.GetComponent<GameDoor>().entered = true;
        }
        if (collision.tag == "MusicBox")
        {

            audioSource.gameObject.GetComponent<AudioPlayer>().PlayFab();
        }

    }
    public void Grow()
    {
        ate = true; // simple 1 segment hack
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            collision.GetComponent<GameDoor>().entered = false;
        }
    }
    public void Pause()
    {
        state = 2; // idle state
    }
    public void Resume()
    {
        state = 1;
    }
    public void Move()
    {
        if(ate)
        {
            GameObject g = (Instantiate(tailPrefab, transform.position, Quaternion.identity));

            tails.Insert(0, g.transform);
            ate = false;
            snakeLength += 1;
        }
        else if (tails.Count > 0)
        {
            tails.Last().position = transform.position; // set last tail to head

            //re order the list
            tails.Insert(0, tails.Last());
            tails.RemoveAt(tails.Count - 1);

        }

        //move
        if (dir == 1)
        {
            transform.Translate(0, moveSize, 0);
        }
        if (dir == 2)
        {
            transform.Translate(moveSize * -1, 0, 0);
        }
        if (dir == 3)
        {
            transform.Translate(0, moveSize * -1, 0);
        }
        if (dir == 4)
        {
            transform.Translate(moveSize, 0, 0);
        }

    }
}

