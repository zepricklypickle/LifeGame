using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SituationFunctionsScript : MonoBehaviour
{
    public int levels;
    public List<GameObject> riddleList = new List<GameObject>(new GameObject[5]);
    public List<GameObject> answerList = new List<GameObject>(new GameObject[5]);

    public int riddle_answerNumber = 0;
    public string riddleName;
    public string answerName;
    public int rightReply = 0;

    // Start is called before the first frame update
    void Start()
    {
        AssignRidandAns();
        HidingRidandAns();        
    }

    public void AssignRidandAns()
    {
        for (int riddleNumber = 0; riddleNumber < 5; riddleNumber++)
        {
            riddleName = "Riddle" + (riddleNumber + 1);
            riddleList[riddleNumber] = GameObject.Find(riddleName);
            answerName = "Answer" + (riddleNumber + 1);
            answerList[riddleNumber] = GameObject.Find(answerName);
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
                Debug.Log(levels + "is inactive");
            }
        }
    }
}
