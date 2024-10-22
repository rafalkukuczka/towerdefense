using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGridController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetActive(0, true); 

        if (GameData.Score > 1000)
        {
            SetActive(1, true);
        }
        else
        {
            SetActive(1, false);
        }

        if (GameData.Score > 2000)
        {
            SetActive(2, true);
        }
        else
        {
            SetActive(2, false);
        }

        if (GameData.Score > 3000)
        {
            SetActive(3, true);
        }
        else
        {
            SetActive(3, false);
        }

        //RK DEBUG
        SetActive(3, true);
    }

    private void SetActive(int idx, bool isActive)
    {
        var levelSelector = this.transform.GetChild(idx).GetComponent<LevelSelectorController>();
        levelSelector.SetActive(isActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
