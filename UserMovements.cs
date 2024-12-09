using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserMovements : MonoBehaviour
{
    private Rigidbody2D userSprite;
    private SpriteRenderer flip;
    private int speed = 50;

    public GameDataManager GameDataManager;
    public InputField FifthRiddleAnswer;

    // Start is called before the first frame update
    void Start()
    {
        GameDataManager = GameObject.Find("SituationFunctions").GetComponent<GameDataManager>();
        //FifthRiddleAnswer = GameObject.Find("FifthRiddleAnswer").GetComponent<Text>()

        if (GameDataManager != null)
        {
            GameDataManager.AssignRidandAns();
            GameDataManager.HidingRidandAns();
        }
        else
        {
            Debug.Log("Script not found");
        }

        userSprite = GetComponent<Rigidbody2D>();
        flip = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))    
        {
            Vector2 movement = new Vector2(moveX, moveY) * speed * Time.deltaTime;
            userSprite.MovePosition(userSprite.position + movement);
            flip.flipY = false;
            //Debug.Log("Movedright");
        }
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))     
        {
            Vector2 movement = new Vector2(moveX, moveY) * speed * Time.deltaTime;
            userSprite.MovePosition(userSprite.position + movement);
            flip.flipY = true;
            //Debug.Log("Movedleft");

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bug"))
        {
            Debug.Log("Hit blue bug");
            GameDataManager.riddleList[GameDataManager.riddle_answerNumber].SetActive(true);
            GameDataManager.answerList[GameDataManager.riddle_answerNumber].SetActive(true);

            /*if (GameDataManager.riddle_answerNumber == 4)
            {
                GameDataManager.answerList[GameDataManager.riddle_answerNumber].SetActive(false);
                FifthRiddleAnswer.SetActive(true);
            }*/
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bug"))
        {
            GameDataManager.riddle_answerNumber = GameDataManager.riddle_answerNumber + 1;            
            if ((GameDataManager.riddle_answerNumber >= 5)&&(FifthRiddleAnswer!=null))
            {
                if (FifthRiddleAnswer.text == "Emotions")
                {
                    GameDataManager.rightReply = GameDataManager.rightReply + 1;
                }
                SceneManager.LoadScene("ResultsScene");
            }
        }
    }
    public void correctAnswer()
    {        
        Debug.Log("correct");
        GameDataManager.rightReply = GameDataManager.rightReply + 1;
        SceneManager.LoadScene("Levels");
        Debug.Log(GameDataManager.rightReply);
    }

    public void OnAnswerClicked()
    {
        if (GameDataManager.riddle_answerNumber < 5)
        {
            Debug.Log("Answer is clicked");
            GameDataManager.rightReply = GameDataManager.rightReply + 0;
            GameDataManager.riddleList[GameDataManager.riddle_answerNumber].SetActive(false);
            GameDataManager.answerList[GameDataManager.riddle_answerNumber].SetActive(false);
            SceneManager.LoadScene("Levels");
            Debug.Log(GameDataManager.rightReply);
        }
    }
}