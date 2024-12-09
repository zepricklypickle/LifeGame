using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugScript : MonoBehaviour
{
    public GameDataManager GameDataManager;

    public Sprite BeetleCharacter;
    public Sprite MothCharacter;
    public Sprite MosquitoCharacter;
    
    public List<Image> BugImages = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {
        GameDataManager = GameObject.Find("SituationFunctions").GetComponent<GameDataManager>();
    }

    void Update()
    {
        if (GameDataManager.riddle_answerNumber == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = BeetleCharacter;
        }
        if (GameDataManager.riddle_answerNumber == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = MosquitoCharacter;

        }
        if (GameDataManager.riddle_answerNumber == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = MothCharacter;
        }    
    }
}