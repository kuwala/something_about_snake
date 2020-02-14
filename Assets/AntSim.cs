using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSim : MonoBehaviour
{
    List<GameObject> tiles;
   //GameObject board;
    public Transform boardHolder;
    public GameObject tilePrefab;
    // Start is called before the first frame update
    private int cols;
    private int rows;
    private bool startHack;
    public Vector2 antPos;
    public Vector2 boardPos;
    int antDir;
    void Start()
    {
        rows = cols = 16;
        antDir = 1; // 0, 1, 2, 3 - East, North, West, South
        antPos = new Vector2((int)(cols / 2),(int)(rows/2));
        //antPos = new Vector2(8, 8);

        startHack = false;


        // 

    }
    private void Awake()
    {

    }
    private void MyStart()
    {
        rows = cols = 16;
        // create gameboard
        tiles = new List<GameObject>();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // instation tiles
                Vector3 pos = new Vector3(j, i, 0);
                //pos.translate(transform.position);
                GameObject clone = Instantiate(tilePrefab, pos, Quaternion.identity);
                clone.transform.SetParent(boardHolder);
                
                tiles.Add(clone);
                // move tiles to correct place
                // add tiles to list
                //needs awake//clone.GetComponent<BoardTile>().SetTileType(0);
            }
        }

        // place ant in center
        int center = ((rows / 2) * cols) + (cols / 2);
        print(16 * 16);
        print(center);
        GameObject centerTile = tiles[center];
        centerTile.SetActive(false);
        //centerTile.GetComponent<BoardTile>().SetTileType(4
        boardPos = boardHolder.position;
        boardHolder.Translate(boardPos);
    }

    // Update is called once per frame
    void Update()
    {
        if(!startHack)
        {
            MyStart();
        
            startHack = true;
            //print("start Hack");
        }
        // A generation update
        // check current Til
        BoardTile tile = GetTileAt((int)antPos.x, (int)antPos.y);
        // flipTile & Rotate ant
        if (tile.GetTileType() == 4)
        {
            tile.SetTileType(5);
            antDir++;
            if (antDir > 3)
                antDir = 0;
            //print("setting Tile to 5");
        }
        else if (tile.GetTileType() == 5)
        {
            tile.SetTileType(4);
            //print("setting Tile to 4");
            antDir--;
            if (antDir < 0)
                antDir = 3;
        }
        //print("ant DIreciton: " + antDir);
        MoveAnt();

    }
    public void MoveAnt()
    {
        //print("moving ant");
        if(antDir == 0)
        {
            antPos.x = (antPos.x + 1) % cols;
        } else if (antDir == 1)
        {
            antPos.y = (antPos.y + 1) % rows;
        } else if (antDir == 2)
        {
            if (antPos.x < 1) // == 0
                antPos.x = cols - 1;
            else
                antPos.x = (antPos.x - 1) % cols;
        } else if (antDir == 3)
        {
            if (antPos.y < 1) // == 0
                antPos.y = rows - 1;
            else
                antPos.y = (antPos.y - 1) % rows;

        }
    }
    public BoardTile GetTileAt(int x, int y)
    {
        int tileNum = y  * cols + x;
        return tiles[tileNum].GetComponent<BoardTile>();
    }
    //public GameObject GetTileAt(Vector2 pos)
    //{
    //    int tileNum = (int)((pos.y / 2) * cols) + pos.x / 2);
    //    return tiles[tileNum];
    //}

}
