using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    // Start is called before the first frame update

    

    public void Reset()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit() 
    {
        Application.Quit();
    }
}
 