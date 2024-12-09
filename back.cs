using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    public int levels;
    public void GoToStart()
    {
        SceneManager.LoadScene("StartingScene");
    }

    public void GoToLevels()
    {
        SceneManager.LoadScene("Levels");
        DontDestroyOnLoad(gameObject);
    }

    public void GoToScenarios()
    {
        SceneManager.LoadScene("Situation");
        DontDestroyOnLoad(gameObject);
    }
}