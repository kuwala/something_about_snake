using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    // Start is called before the first frame update
    // On enter start delay
    // once delayed
    // check if still inside
    // then trigger exit application.
    bool triggered;
    public float waitTime = 2f;

    void Start()
    {
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //collision.attachedRigidbody.AddForce(Vector2.down * 2f, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggered = true;
        print("entered");
        StartCoroutine(TimeDelayed());
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        triggered = false;
        print("exit");
    }
    IEnumerator TimeDelayed()
    {
        yield return new WaitForSeconds(waitTime);
        print("triggered: ");
        if (triggered)
            Application.Quit();
        yield return null;
    }
}
