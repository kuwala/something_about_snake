using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class snakePlayer : MonoBehaviour
{

    Transform t;
    public int dir = 0;
    public int snakeLength = 0;
    public GameObject tailPrefab;
    public Vector2 lastLocation;
    public Vector2 currentLocation;
    private readonly int framesPerTick = 8;
    private int frames;
    private readonly float moveSize = 1.0f;

    private int growLength;
    private List<Transform> tails;
    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        frames = 0;
        alive = true;
        lastLocation = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
        currentLocation = lastLocation;

        growLength = 0; // when ate
        tails = new List<Transform>();

        InvokeRepeating("Move", 0.05f, 0.05f);

        for (int i =0; i < snakeLength; i ++)
        {


            // make snake block
            Vector3 pos =  new Vector3(transform.position.x, transform.position.y+i, transform.position.z);
            GameObject tail = Instantiate(tailPrefab, pos, Quaternion.identity);
            tail.transform.SetParent(transform.parent);
            tails.Insert(0, tail.transform);
            //tail.transform.position = new Vector3(transform.position.x, transform.position.y +i *1.0f, transform.position.z);
        }
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Application.LoadLevel(0);
    
        frames++;
        //if(frames % framesPerTick == 0)
        if (alive)
        {
            //dir = -1;
            if (Input.GetKey("w"))
            {
                if(dir!=3) dir = 1;


            }
            if (Input.GetKey("a"))
            {

                if(dir!=4) dir = 2;


            }
            if (Input.GetKey("s"))
            {
                if(dir!=1) dir = 3;


            }
            if (Input.GetKey("d"))
            {
                if(dir!=2) dir = 4;


            }
            //Move();


        }// tick update

    } // end update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {

            growLength += 2;
            Destroy(collision.gameObject);
        }
        else if(collision.tag == "Tail")
        {
            print("tail");
            // Game Over
            alive = false;
            //wait for tail to close then destroy
        }
    }
    public void Move()
    {
        if (growLength > 0)
        {
            GameObject g = (Instantiate(tailPrefab, transform.position, Quaternion.identity));

            tails.Insert(0, g.transform);
            growLength--;
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
    public void CleanUp()
    {
        if(tails!= null)
        {
            for (int i = 0; i < tails.Count; i++)
            {
                Destroy(tails[i].gameObject);
            }
        }

    }
}

