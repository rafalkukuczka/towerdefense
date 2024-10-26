using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void Reset()
    {
        GameData.Score = 0;
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit() 
    {
        Application.Quit();
    }
}
 