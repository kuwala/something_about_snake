using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject food;
    public Vector2 distance = new Vector2( 30f, 30f);
    private int frames;
    private List<GameObject> list;
    // Start is called before the first frame update
    void Start()
    {
        frames = 0;
        list = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        if(frames % 30 == 0)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        Vector3 pos = new Vector3(transform.position.x + Random.Range(0, distance.x), transform.position.y + Random.Range(0, distance.y), transform.position.z);
        GameObject obj = Instantiate(food, pos, Quaternion.identity);
        list.Add(obj);
    }
    public void CleanUp()
    {
        if(list != null)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Destroy(list[i]);
            }
        }
       
    }
}
