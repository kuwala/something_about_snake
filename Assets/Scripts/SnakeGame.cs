using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SnakeGame : MonoBehaviour
{
    // Start is called before the first frame update
    private int state;
    public Transform cameraPos;
    public Transform snakeStart;
    public GameObject worldPlayer;
    public CameraFollower cameraFollower;
    public GameObject playerPrefab;
    public GameObject gameBoard;
    public GameDoor gameDoor;
    public FoodSpawner foodSpawner;
    public AudioSource worldAudio;

    public GameObject scoreObj;


    private int score;
    private int topScore;
    private bool gameOver;

    private GameObject snake;

    void Start()
    {
        gameOver = false;
        state = 0;
        score = 0;
        topScore = 0;
        snake = null;

    }

    // Update is called once per frame
    void Update()
    {
        if(state == 0) // idle state
        {
            if (gameDoor.entered) // start game
            {
                StartGame();
                
            }
        } else if(state == 1) // active state
        {
            gameOver = !snake.GetComponent<snakePlayer>().alive;
            print("from snameGame: ");
            print(snake.GetComponent<snakePlayer>().alive);
            print(gameOver);
            if (gameOver)
            {
                //delete snake player
                EndGame();
                state = 0;
                //re enable player
            }

            if (Input.GetKey("q"))
            {
                EndGame();
            }

            if(score > topScore)
            {
                topScore = score;
            }

            score = snake.GetComponent<snakePlayer>().snakeLength;
            //scoreText.text = "Score: " + score;
            //scoreObj.GetComponent<TextMeshPro>().text = "Score: " + score;
            scoreObj.GetComponent<TextMeshProUGUI>().text = "TopScore: "+ topScore + " " +"Score: " + score+ "         Press q:quit";
            
        }


    }
    private void StartGame()
    {
        worldAudio.gameObject.GetComponent<AudioPlayer>().PlayFab();
        state = 1;
        score = 0;
        worldPlayer.GetComponent<SnakePlayerSmooth>().Pause();
        foodSpawner.gameObject.SetActive(true);

        snake = Instantiate(playerPrefab, snakeStart.position, Quaternion.identity);
        // move camera
        cameraFollower.SetStaticPosition(cameraPos);
        // disable player
    }
    private void EndGame()
    {
        worldAudio.gameObject.GetComponent<AudioPlayer>().PlayHome7();

        state = 0;
        cameraFollower.StartFollow();
        snake.GetComponent<snakePlayer>().CleanUp();
        Destroy(snake);
        gameDoor.entered = false;
        worldPlayer.GetComponent<SnakePlayerSmooth>().Resume();
        foodSpawner.CleanUp();
        foodSpawner.gameObject.SetActive(false);
    }

}
