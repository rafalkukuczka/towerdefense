using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGridController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetActive(1, true);

        SetActive(2, GameData.IsSecondScreenVisible());

        SetActive(3, GameData.IsThirdScreenVisible());

        SetActive(4, GameData.IsForthScreenVisible());

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
}
