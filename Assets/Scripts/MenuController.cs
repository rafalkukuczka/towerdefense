using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public int LevelNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnSelect()
    {
        if (LevelNumber == 0)
            return;

        SceneManager.LoadScene("Level" + LevelNumber.ToString());
    }
}
