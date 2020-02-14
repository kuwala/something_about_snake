using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    public Sprite tile0;
    public Sprite tile1;
    public Sprite tile2;
    public Sprite tile3;
    private SpriteRenderer sr;
    private int type;
    // Start is called before the first frame update
    void Start()
    {

        
        //sr = GetComponent<SpriteRenderer>();
        //sr.sprite = tile0;
        type = 5;
        SetTileType(type);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void SetTileType(int _type)
    {
        type = _type;
        sr = GetComponent<SpriteRenderer>();
        switch (type)
        {
            case 0:
                sr.sprite = tile0;
                break;
            case 1:
                sr.sprite = tile1;
                break;
            case 2:
                sr.sprite = tile2;
                break;
            case 3:
                sr.sprite = tile3;
                print("3 called");
                break;
            case 4:
                sr.sprite = tile0;
                gameObject.SetActive(false); // black
                break;
            case 5:
                sr.sprite = tile0;
                gameObject.SetActive(true);
                break;
            default:
                print("Tile number out of range");
                break;
        }
    }
    public int GetTileType()
    {
        return type;
    }
}
