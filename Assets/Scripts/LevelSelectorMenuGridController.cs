using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGridController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetActive(1, true);

        SetActive(2, GameData.IsSecondLevelVisible());

        SetActive(3, GameData.IsThirdLevelVisible());

        SetActive(4, GameData.IsForthLevelVisible());
        
        SetActive(5, GameData.IsFifthLevelVisible());

    }

    private void SetActive(int idx, bool isActive)
    {
        var levelSelector = this.transform.GetChild(idx-1).GetComponent<LevelSelectorController>();
        levelSelector.SetActive(isActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy()
    {
        GameData.Score = 0;
        SceneManager.LoadScene("ShopMenu");
    }


    public void Exit()
    {
        Application.Quit();
    }
}
