using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultsScript : MonoBehaviour
{
    public GameDataManager GameDataManager;
    public TMP_Text resultsText;
    public string resultTextValue;

    // Start is called before the first frame update
    void Start()
    {
        GameDataManager = GameObject.Find("SituationFunctions").GetComponent<GameDataManager>();
        resultsText = FindAnyObjectByType<TMP_Text>();
        //int rightReply = GameDataManager.rightReply;
        GameDataManager.rightReply.ToString();
        resultTextValue = "You answered " + GameDataManager.rightReply + " riddles correctly";
        resultsText.SetText(resultTextValue);

    }
}