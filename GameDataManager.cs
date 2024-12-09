using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;
    public List<GameObject> riddleList = new List<GameObject>();
    public List<GameObject> answerList = new List<GameObject>();
    public int riddle_answerNumber = 0;
    public string riddleName;
    public string answerName;
    public int rightReply = 0;
    public int levels = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        InitializeLists();
        AssignRidandAns();
        HidingRidandAns();
    }
    private void InitializeLists()
    {
        // Clear lists to avoid duplicates if Start is called multiple times
        riddleList.Clear();
        answerList.Clear();

        for (int i = 0; i < 5; i++)
        {
            riddleList.Add(null);
            answerList.Add(null);
        }
    }

    public void AssignRidandAns()
    {
        for (int riddleNumber = 0; riddleNumber < 5; riddleNumber++)
        {
            riddleName = "Riddle" + (riddleNumber + 1);
            riddleList[riddleNumber] = GameObject.Find(riddleName);
            answerName = "Answer" + (riddleNumber + 1);
            answerList[riddleNumber] = GameObject.Find(answerName);
            Debug.Log("Found stuff to populate with");
        }
    }

    public void HidingRidandAns()
    {
        if ((riddleList[0] != null) && (answerList[0] != null))
        {
            for (levels = 0; levels < 5; levels++)
            {
                riddleList[levels].SetActive(false);
                answerList[levels].SetActive(false);
                Debug.Log(levels + " is inactive");
            }
        }
    }

    public void Results()
    {        
            Debug.Log("You answered " + rightReply + "correctly");        
    }

    public void CompleteGame()
    {
        if (riddle_answerNumber == 5)
        {
            SceneManager.LoadScene("ResultsScene");
        }
    }
}
